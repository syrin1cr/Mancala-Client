using System.Threading.Tasks;
using System.Net.Sockets;
using System.IO;
using Mancala_Console;
using System.Collections;

namespace CIS311_Assignment10_Client
{
    /// <summary>
    /// /// <summary>
    /// Author: Cody Syring
    /// Filename: Form1.cs
    /// Part of Project: CIS311_Assignment10_Client.cs
    /// 
    /// File Purpose:
    /// This files purpose is to be a client for a game of Mancala.
    /// It will handle:
    /// sending and recieving of messages to and from the server.
    /// updating the game board according to user action or messages from server.
    /// control win/lose/tie logic.
    /// 
    /// </summary>

    // YOUR CODE -- YOUR CODE -- YOUR CODE -- YOUR CODE -- YOUR CODE -- YOUR CODE
    // YOUR CODE -- YOUR CODE -- YOUR CODE -- YOUR CODE -- YOUR CODE -- YOUR CODE
    // YOUR CODE -- YOUR CODE -- YOUR CODE -- YOUR CODE -- YOUR CODE -- YOUR CODE
    public partial class ClientForm : Form
    {
       
        TcpClient Client;

        Socket aConnection;

        NetworkStream NetStream;

        BinaryWriter NetWriter;
        BinaryReader NetReader;

        Task GetDataTask;
        bool myTurn = true;

        Button[] btnArray;
        MancalaBoard board;
        bool sendData = false;

        public ClientForm()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            cmdDisconnectFromServer.Enabled = false;
        }


        private void cmdConnectToServer_Click(object sender, EventArgs e)
        {


            // Try to make a connection to the server
            try
            {

                Client = new TcpClient();
                Client.Connect(txtServerIPAddress.Text,
                               int.Parse(txtServerPort.Text));

                NetStream = Client.GetStream();

                NetWriter = new BinaryWriter(NetStream);
                NetReader = new BinaryReader(NetStream);

                cmdDisconnectFromServer.Enabled = true;
                cmdConnectToServer.Enabled = false;


                GetDataTask = Task.Run(GetDataFromServer);
            }

            catch (IOException IOEx)
            {
                txtMessages.Text +=
                      "Error in setting up Client -- Closing\r\n";
            }

            //Catch errors in trying to connect when a server is not present
            catch (SocketException SocketEx)
            {
                txtMessages.Text +=
                    "Cannot find server -- please try again later\r\n";
            }
        }
        private void UpdateTextbox(TextBox tBox, string text)
        {
            if (tBox.InvokeRequired)
            {
                Action safeWrite = delegate { UpdateTextbox(tBox, text); };

                tBox.Invoke(safeWrite);
            }
            else
            {
                tBox.Text = text;
            }

        }


        private void cmdDisconnectFromServer_Click(object sender,
                                                     EventArgs e)
        {
            // Whenever the user presses the Disconnect button, we simply 
            // call the DisconnectClient routine
            DisconnectClient();
        }


        void DisconnectClient()
        {


            ControlInvokeAction<Button>(cmdConnectToServer,
                    cmd => cmd.Enabled = true);
            ControlInvokeAction<Button>(cmdDisconnectFromServer,
                    cmd => cmd.Enabled = false);

            try
            {
                if (NetWriter != null)
                    NetWriter.Write("~~END~~");
            }
            catch (Exception Ex)
            {
                // We don't need to do anything, but there was a problem
                // communicating with the server
            }

            try
            {
                // Destroy all of the objects that we created
                if (NetWriter != null)
                    NetWriter.Close();
                if (NetReader != null)
                    NetReader.Close();
                if (NetStream != null)
                    NetStream.Close();
                if (Client != null)
                    Client.Close();
                NetWriter = null;
                NetReader = null;
                NetStream = null;
                Client = null;

                try
                {
                    // GetDataThread.Abort()
                    if (GetDataTask != null)
                        GetDataTask = null;
                }
                catch (Exception Ex)
                {
                    // We don't care since we are trying to stop the thread
                }
            }

            catch (Exception Ex)
            {
                // We don't have to do anything since we are leaving anyway
            }
            finally
            {
                // txtMessages.Text += "Disconnected...client closed\r\n";
                ControlInvokeAction<TextBox>(txtMessages, txt => txt.Text +=
                        "Disconnected...client closed\r\n");
            }
        }


        public static void ControlInvokeAction<ctlType>(ctlType controlName,
                               Action<ctlType> propToSet)
                                  where ctlType : Control
        {
            // Even though the syntax is more convoluted here, it is the 
            // exact same principle as our earlier method

            // Does the control require an Invoke to update the property?
            if (controlName.InvokeRequired)
            {
                // If yes, place a message on the control's message queue to 
                // perform a property update.
                controlName.Invoke(new Action<ctlType,
                                   Action<ctlType>>(ControlInvokeAction),
                                   new object[] { controlName, propToSet });
            }
            else
            {
                // If not (or if it is the recursive callback from the
                // InvokeRequired, just go ahead and change the property's
                // value via what the lambda says to do.
                propToSet(controlName);
            }
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // If the user closes the form, make sure we shut things down 
            // properly
            DisconnectClient();
        }

        // MY CODE -- MY CODE -- MY CODE -- MY CODE -- MY CODE -- MY CODE
        // MY CODE -- MY CODE -- MY CODE -- MY CODE -- MY CODE -- MY CODE
        // MY CODE -- MY CODE -- MY CODE -- MY CODE -- MY CODE -- MY CODE
        // MY CODE -- MY CODE -- MY CODE -- MY CODE -- MY CODE -- MY CODE

        /// <summary>
        /// This method will update the board so you can take your turn.
        /// </summary>
        private void setTurnMine()
        {
            int[] myBoard = board.playerHalf;

            foreach (int i in myBoard)
            {           
                UpdateButton(btnArray[i], true); 
            }
        }
        /// <summary>
        /// This method is for the safe update of buttons with in threads.
        /// </summary>
        /// <param name="button"></param>   button we are going to update.
        /// <param name="enabled"></param>  state we want to leave it in.
        private void UpdateButton(Button button, bool enabled)
        {
            if (button.InvokeRequired)
            {
                button.Invoke(new Action<Button, bool>(UpdateButton), button, enabled);
            }
            else
            {
                button.Enabled = enabled;
            }
        }
        /// <summary>
        /// This method will set the game board up so the user can't interact with the
        /// buttons.
        /// </summary>
        private void setTurnNotMine()
        {
            foreach (Button i in btnArray)
            {
                UpdateButton(i, false);
            }
        }
        /// <summary>
        /// This method will update all the buttons that act as our gameboard.
        /// </summary>
        private void pushToUI()
        {
            int x = 0;
            int[] tempBoard = board.getBoard();

            foreach (Button currentButton in btnArray)
            {
                UpdateButtonText(currentButton, tempBoard[x].ToString());
                x++;
            }
        }
        /// <summary>
        /// This method will handle the updating of buttons within
        /// threads.
        /// </summary>
        /// <param name="button"></param>
        /// <param name="text"></param>
        private void UpdateButtonText(Button button, string text)
        {
            if (button.InvokeRequired)
            {
                button.BeginInvoke(new Action<Button, string>(UpdateButtonText), button, text);
            }
            else
            {
                button.Text = text;
            }
        }
        /// <summary>
        /// This method will send a message to the server. It will also
        /// handle win/lose/tie logic.
        /// </summary>
        /// <param name="btnClicked"></param>   Is the number sent in
        ///                                     when a user clicks their
        ///                                     bucket / turn.
        private void takeTurn(int btnClicked)
        {
            int lastPebbleDroppedAt = board.takeTurn(btnClicked);
            pushToUI();

            try
            {
                // Assuming that our network connection to the client is
                // still good, we should be able to send the textbox's
                // contents over the network stream
                if (NetWriter != null)
                    NetWriter.Write(btnClicked.ToString());

                txtMessages.Text += "Your Turn:" + board.createString() + Environment.NewLine;

                if (0 == board.calcMarblesMySide())
                {//This block is fired only if a winner needs to be found.
                    setTurnNotMine();
                    txtMessages.Text += board.didWin() + "\n";
                }
                else if (lastPebbleDroppedAt - 1 == board.myPointFlag)
                {
                    //This does nothing :)
                    //Skips changing the turn.
                }
                else
                {
                    setTurnNotMine();
                }

            }

            // We tried to write to the client and it wasn't there
            catch (SocketException SocketEx)
            {
                txtMessages.Text += "Error writing to client\r\n";
            }

            catch (Exception Ex)
            {
                // Some other exception occurred, don't worry about it
                // at this point.
            }
        }
        /// <summary>
        /// This method will handle some setup when the form is first opened.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClientForm_Load(object sender, EventArgs e)
        {
            board = new MancalaBoard(2);
            btnArray = new Button[] { btn0, btn1, btn2, btn3, btn4, btn5, btn6, btn7, btn8, btn9, btn10, btn11 };
            pushToUI();
            setTurnNotMine();
        }
        /// <summary>
        /// This method is for the safe update of txtMessage while
        /// we are within a thread.
        /// </summary>
        /// <param name="message"></param>
        private void UpdateMessagesTextBox(string message)
        {
            if (txtMessages.InvokeRequired)
            {
                txtMessages.Invoke(new Action<string>(UpdateMessagesTextBox), message);
            }
            else
            {
                txtMessages.Text += message;
            }
        }
        /// <summary>
        /// This method is the listener. Waits for the server to send a message.
        /// It will handle turn control along with board updating when needed.
        /// It also makes sure the users still have the ability to move a marble.
        /// If they don't it will display the win/loss/tie message.
        /// </summary>
        void GetDataFromServer()
        {

            /* This is the routine that we spin off into its own task to 
            // listen for and retrieve network traffic coming to the client
            // from the server.


            //This is a string that we use to pull the data off of the
            //network stream
            */
            string TheData = "";
            int endLocation = 0;

            /*
            // This commented out next line will not work because this
            // task (which is a thread behind the scenes) is receiving
            // the data and the thread that has the GUI are different.
            // You will receive the error "Cross-thread operation not
            // valid: Control accessed from a thread other than from
            // the thread it was created on."

            // txtMessages.Text += "Data watching thread active\r\n";

            // The error message is 100% accurate because our GUI was
            // instantiated on the first thread when we launched the
            // application and this listener task/thread is trying to
            // manipulate a control that it didn't create.  This can
            // put the control in an inconsistent state.  A cheap
            // cop-out is to use what I showed in Form_Load:
            // CheckForIllegalCrossThreadCalls = false; and that's
            // what we did over on the server side so that we could
            // just concentrate on understanding the network programming
            // involved in the application.  This single line of code
            // basically just turns off watching for the problem.
            // Turning a blind eye to it will work in some cases, like
            // this program.  But, in other applications you end up with
            // a mess.  We will learn how to properly address this problem
            // in this method.

            // The first thing we will do is get the text string that
            // we want updated in some GUI textbox loaded up with the
            // information that's supposed to be put in the textbox.
            // That is what goes into this textToWriteSomewhere variable.
            */
            string textToWriteSomewhere = "";

            /*
            // We are now going to call a method that can safely update
            // the textbox regardless if it was created on this task/thread
            // or not.  The code for this appears below.  We send two
            // parameters: the name of the textbox to update and the new
            // text to put in the textbox.  There will be no cross
            // threading complaints when we do this.*/

            /*
            // Here's the main listening loop that will continue until we
            // receive the ~~END~~ message from the server or our connection
            // abruptly stops.*/
            try
            {
                string player1Or2 = NetReader.ReadString();
                this.board = new MancalaBoard(int.Parse(player1Or2));
             
                if (int.Parse(player1Or2) == 1)
                {
                    setTurnMine();
                    textToWriteSomewhere = "You are player 1. You go first." + Environment.NewLine;
                }
                else
                {
                    setTurnNotMine();
                    textToWriteSomewhere = "You are player 2. You go second." + Environment.NewLine;
                }
                UpdateMessagesTextBox(textToWriteSomewhere);

                do
                {
                    //Pull data from the network into our string
                    TheData = NetReader.ReadString();
                    /*
                    // Shove the contents of the string into the textbox
                    // txtYourConversation.Text = TheData;

                    // Conceptually the line above is correct with our
                    // intent, but it will generate another cross thread
                    // issue.  We aleady have the solution in place, so
                    // we just need to call it:
                    */
                    textToWriteSomewhere = TheData;
                    endLocation = board.theirTurn(int.Parse(textToWriteSomewhere));
                    pushToUI();
                    txtMessages.Text += "Their Turn:" + board.createString() + Environment.NewLine;

                    if (0 == board.calcMarblesNotMySide())
                    {//This block is fired only if a winner needs to be found.
                        setTurnNotMine();
                        txtMessages.Text += board.didWin() + "\n";
                    }
                    else if (endLocation - 1 == board.notMyPointFlag)
                    {
                        //This does nothing :)
                        //Skips changing the turn.
                    }             
                    else
                    {
                        setTurnMine();
                    }


                }
                while (TheData != "~~END~~");
                DisconnectClient();
            }

            // Catch errors when trying to read or write and the stream
            // is not there
            catch (IOException IOEx)
            {
                // Here's another cross thread issue and the fix:
                // txtMessages.Text += "Closing connection with 
                //                      client...\r\n";
                DisconnectClient();
            }
        }

        /// <summary>
        /// All methods after this point handle click events of the buttons.
        /// They will have no action if their text is set to 0.
        /// and will call takeTurn({#assignt to chosen button})
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn0_Click(object sender, EventArgs e)
        {
            if(btn0.Text != "0")
                takeTurn(0);
        }
        private void btn1_Click(object sender, EventArgs e)
        {
            if (btn1.Text != "0")
                takeTurn(1);
        }
        private void btn2_Click(object sender, EventArgs e)
        {
            if (btn2.Text != "0")
                takeTurn(2);
        }
        private void btn3_Click(object sender, EventArgs e)
        {
            if (btn3.Text != "0")
                takeTurn(3);
        }
        private void btn4_Click(object sender, EventArgs e)
        {
            if (btn4.Text != "0")
                takeTurn(4);
        }
        private void btn5_Click(object sender, EventArgs e)
        {
            if (btn5.Text != "0")
                takeTurn(5);
        }
        private void btn6_Click(object sender, EventArgs e)
        {
            if (btn6.Text != "0")
                takeTurn(6);
        }
        private void btn7_Click(object sender, EventArgs e)
        {
            if (btn7.Text != "0")
                takeTurn(7);
        }
        private void btn8_Click(object sender, EventArgs e)
        {
            if (btn8.Text != "0")
                takeTurn(8);
        }
        private void btn9_Click(object sender, EventArgs e)
        {
            if (btn9.Text != "0")
                takeTurn(9);
        }
        private void btn10_Click(object sender, EventArgs e)
        {
            if (btn10.Text != "0")
                takeTurn(10);
        }
        private void btn11_Click(object sender, EventArgs e)
        {
            if (btn11.Text != "0")
                takeTurn(11);
        }
    }
}