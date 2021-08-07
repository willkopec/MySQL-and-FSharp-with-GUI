using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proj5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        static Microsoft.FSharp.Collections.FSharpList<string> F4()
        {
            return HW5P2Lib.HW5P2.publishers(alldata);
        }

        static Microsoft.FSharp.Collections.FSharpList<HW5P2Lib.HW5P2.Article> alldata;
        string filenameForFS = "dataMedium.csv";
        static string inputChosen = "1"; //use default string as 1 to prevent error
        static string server;
        static string port;
        static string username;
        static string password;
        static string database2;
        static string chatResult;

        int inputInt;


        static MySqlConnection conn;

        static void establishConnection()
        {
            chatResult += "Testing Connection to MySQL Server..." + Environment.NewLine;
            string connStr = ("server=" + server + ";user=" + username + ";database=" + database2 + ";port=" + port + ";password=" + password); // "server=localhost;user=root;database=hw5;port=3306;password=willy202";  // change the database and password to test on your machine
            //Default: ("server=" + server + ";user=" + username + ";database=" + database2 + ";port=" + port + ";password=" + password)
            conn = new MySqlConnection(connStr);                                                     // must be these values when submitting to gradescope
            conn.Open();
            chatResult += "Established Connection to MySQL Server." + Environment.NewLine;
        }

        //createResultMessage:
        //
        // This function takes the input from the user's choices from the textboxs and 
        // appends the strings as such to create a intro message (Without the result)
        //
        public void createResultMessage (string filename, string input, string database1, string port, string username, string password, string database2)
        {
            chatResult += "Opening and reading file: " + filename + Environment.NewLine;
            alldata = HW5P2Lib.HW5P2.readfile(filename);
            chatResult += "You chose input : " + input + Environment.NewLine;

            chatResult += "Result : " + Environment.NewLine;
            chatResult += "---------" + Environment.NewLine;
        }

        //All F# and SQL functions:
        //-------------------------
        //

        //F# 1
        private void button1_Click(object sender, EventArgs e)
        {
            createResultMessage(filenameForFS, inputChosen, server, port, username, password, database2);
            chatResult += "1. title: " + Environment.NewLine;
            chatResult += HW5P2Lib.HW5P2.getTitle(inputInt, alldata) + Environment.NewLine; //append result to the chatResult string
            inputInt = Int32.Parse(inputChosen);
            textBox1.Text = chatResult;
            chatResult = ""; //reset the result string to get rid of previous result(s)
        }
        //F# 2
        private void button2_Click(object sender, EventArgs e)
        {
            createResultMessage(filenameForFS, inputChosen, server, port, username, password, database2);
            chatResult += "2. Number of Words in The Article: " + Environment.NewLine + HW5P2Lib.HW5P2.wordCount(inputInt, alldata) + Environment.NewLine; //append result to the chatResult string
            inputInt = Int32.Parse(inputChosen);
            textBox1.Text = chatResult;
            chatResult = "";
        }
        //F# 3
        private void button3_Click(object sender, EventArgs e)
        {
            createResultMessage(filenameForFS, inputChosen, server, port, username, password, database2);
            chatResult += "3. Month of Chosen Article: " + Environment.NewLine + HW5P2Lib.HW5P2.getMonthName(inputInt, alldata) + Environment.NewLine; //append result to the chatResult string
            inputInt = Int32.Parse(inputChosen);
            textBox1.Text = chatResult;
            chatResult = "";
        }
        //F# 4
        private void button4_Click(object sender, EventArgs e)
        {
            createResultMessage(filenameForFS, inputChosen, server, port, username, password, database2);
            Microsoft.FSharp.Collections.FSharpList<string> publisherNames = HW5P2Lib.HW5P2.publishers(alldata);
            chatResult += "4. Unique Publishers:  " + Environment.NewLine + String.Join(Environment.NewLine, publisherNames) + Environment.NewLine;
            textBox1.Text = chatResult;
            chatResult = "";
        }
        //F# 5
        private void button5_Click(object sender, EventArgs e)
        {
            createResultMessage(filenameForFS, inputChosen, server, port, username, password, database2);
            Microsoft.FSharp.Collections.FSharpList<string> countryNames = HW5P2Lib.HW5P2.countries(alldata);
            chatResult += "5. Unique Countries:  " + Environment.NewLine + String.Join(Environment.NewLine, countryNames) + Environment.NewLine;
            textBox1.Text = chatResult;
            chatResult = "";
        }
        //F# 6
        private void button6_Click(object sender, EventArgs e)
        {
            createResultMessage(filenameForFS, inputChosen, server, port, username, password, database2);
            double overallguard = HW5P2Lib.HW5P2.avgNewsguardscoreForArticles(alldata);
            chatResult += "6. Average News Guard Score for All Articles: " + Environment.NewLine + overallguard + Environment.NewLine;
            textBox1.Text = chatResult;
            chatResult = "";
        }
        //F# 7
        private void button7_Click(object sender, EventArgs e)
        {
            createResultMessage(filenameForFS, inputChosen, server, port, username, password, database2);
            Microsoft.FSharp.Collections.FSharpList<Tuple<string, int>> nArticles = HW5P2Lib.HW5P2.numberOfArticlesEachMonth(alldata);
            chatResult += "7. Number of Articles for Each Month: " + Environment.NewLine + HW5P2Lib.HW5P2.buildHistogram(nArticles, alldata.Length, "").Replace("\n", Environment.NewLine) + Environment.NewLine;
            textBox1.Text = chatResult;
            chatResult = "";
        }
        //F# 8
        private void button8_Click(object sender, EventArgs e)
        {
            createResultMessage(filenameForFS, inputChosen, server, port, username, password, database2);
            Microsoft.FSharp.Collections.FSharpList<Tuple<string, double>> reliablepct = HW5P2Lib.HW5P2.reliableArticlePercentEachPublisher(alldata);
            Microsoft.FSharp.Collections.FSharpList<string> lines1 = HW5P2Lib.HW5P2.printNamesAndPercentages(reliablepct);
            chatResult += "8. Percentage of Articles That Are Reliable for Each Publisher: " + Environment.NewLine;
            
            foreach (string line in lines1)
            {
                chatResult += line.Replace("\n", Environment.NewLine);
            }            
            textBox1.Text = chatResult;
            chatResult = "";
        }
        //F# 9
        private void button9_Click(object sender, EventArgs e)
        {
            createResultMessage(filenameForFS, inputChosen, server, port, username, password, database2);
            Microsoft.FSharp.Collections.FSharpList<Tuple<string, double>> countries = HW5P2Lib.HW5P2.avgNewsguardscoreEachCountry(alldata, countryNames: " ");
            chatResult += "9. Average News Guard Score for Each Country: " + Environment.NewLine;
            foreach (Tuple<string, double> dataDisplay in countries)
            {
                string second = String.Format("{0:F3}", (dataDisplay.Item2 * 1000) / 1000);
                chatResult += (dataDisplay.Item1 + ": " + second) + Environment.NewLine;
            }
            textBox1.Text = chatResult;
            chatResult = "";
        }
        //F# 10
        private void button10_Click(object sender, EventArgs e)
        {
            createResultMessage(filenameForFS, inputChosen, server, port, username, password, database2);
            Microsoft.FSharp.Collections.FSharpList<Tuple<string, double>> newsGuard = HW5P2Lib.HW5P2.avgNewsguardscoreEachBias(alldata);
            chatResult += "10. The Average News Guard Score for Each Political Bias Category: " + Environment.NewLine;
            chatResult += HW5P2Lib.HW5P2.buildHistogramFloat(newsGuard, stringSoFar: "").Replace("\n", Environment.NewLine);
            textBox1.Text = chatResult;
            chatResult = "";
        }
        //SQL 1
        private void button11_Click(object sender, EventArgs e)
        {
            establishConnection();
            try
            {
                // Write (copy from queries folder) the query, using the news id read from the user
                //      You can use @" to begin a raw string, which allows for multiple lines in the string
                //int nid;
                string g = String.Format(@"-- 1.	Write a SQL query which, given a news id stored in the variable @nid, generates a table containing the title of the article with that id.
-- SET @nid = 1;
-- set in the database load?

SELECT title
FROM news
WHERE news_id = {0};", inputInt);
                // Build a Command which holds the query and the location of the target server
                MySqlCommand cmd = new MySqlCommand(g, conn);
                // Retrieve the results into a DataReader
                MySqlDataReader rdr = cmd.ExecuteReader();
                // Output the header from the DataReader
                chatResult += String.Format("{0}" + Environment.NewLine, rdr.GetName(0));
                // Loop through the rows of the DataReader to output the values from the DataReader
                while (rdr.Read())
                {
                    chatResult += String.Format("{0}", rdr.GetString(0)) + Environment.NewLine;
                }
                // Close the DataReader
                rdr.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            textBox1.Text = chatResult;
            chatResult = "";
        }
        //SQL 2
        private void button12_Click(object sender, EventArgs e)
        {
            establishConnection();
            MySqlDataReader reader;

            try
            {
                // Write (copy from queries folder) the query
                string query = String.Format(@" 
                                                SELECT news_id, LENGTH(body_text) AS length
                                                FROM news
                                                WHERE LENGTH(body_text)>100
                                                ORDER BY news_id;
                                            ");

                // Build a Command which holds the query and the location of the target server
                MySqlCommand cmd = new MySqlCommand(query, conn);
                // Retrieve the results into a DataReader
                reader = cmd.ExecuteReader();

                // Output the header from the DataReader
                chatResult += String.Format("{0}\t{1}", reader.GetName(0), reader.GetName(1)) + Environment.NewLine;
                // Loop through the rows of the DataReader to output the values from the DataReader
                while (reader.Read())
                {
                    chatResult += String.Format("{0}\t{1}", reader.GetString(0), reader.GetInt32(1)) + Environment.NewLine;
                }



                // Close the DataReader
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            textBox1.Text = chatResult;
            chatResult = "";
        }
        //SQL 3
        private void button15_Click(object sender, EventArgs e)
        {
            establishConnection();
            try
            {
                // Write (copy from queries folder) the query, using the news id read from the user
                //      You can use @" to begin a raw string, which allows for multiple lines in the string
                //int nid;
                string g = @"-- 3.	Write a SQL query which produces a table containing the title and month of each article. 

SELECT title, DATE_FORMAT(STR_TO_DATE(publish_date, '%c/%d/%y'), '%M') AS Month
FROM news
ORDER BY STR_TO_DATE(publish_date, '%m/%d/%y')";
                // Build a Command which holds the query and the location of the target server
                MySqlCommand cmd = new MySqlCommand(g, conn);
                // Retrieve the results into a DataReader
                MySqlDataReader rdr = cmd.ExecuteReader();
                // Output the header from the DataReader
                chatResult += String.Format("{0}\t{1}", rdr.GetName(0), rdr.GetName(1)) + Environment.NewLine;
                // Loop through the rows of the DataReader to output the values from the DataReader
                while (rdr.Read())
                {
                    chatResult += String.Format("{0}", rdr.GetString(0)) + Environment.NewLine;
                }
                // Close the DataReader
                rdr.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            textBox1.Text = chatResult;
            chatResult = "";
        }
        //SQL 4
        private void button14_Click(object sender, EventArgs e)
        {
            establishConnection();
            try
            {
                // Write (copy from queries folder) the query
                string g = @"-- 4.	Write a SQL query which produces a table of unique publisher names that have news articles in the data set.

SELECT publisher
FROM publisher_table
JOIN news
USING (publisher_id)
GROUP BY publisher
ORDER BY publisher;";
                // Build a Command which holds the query and the location of the target server
                MySqlCommand cmd = new MySqlCommand(g, conn);
                // Retrieve the results into a DataReader
                MySqlDataReader rdr = cmd.ExecuteReader();
                // Output the header from the DataReader
                chatResult += rdr.GetName(0) + Environment.NewLine;
                // Loop through the rows of the DataReader to output the values from the DataReader
                while (rdr.Read())
                {
                    chatResult += rdr.GetString(0) + Environment.NewLine;
                }
                // Close the DataReader
                rdr.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            textBox1.Text = chatResult;
            chatResult = "";
        }
        //SQL 5
        private void button13_Click(object sender, EventArgs e)
        {
            establishConnection();
            try
            {
                // Write (copy from queries folder) the query
                string g = @"-- 5.	Write a SQL query which which produces a table containing the 
-- name of each country and the count of how many articles are in the dataset from each country.

SELECT country, COUNT(news_id) AS articleCount
FROM country_table
LEFT JOIN news
USING (country_id)
GROUP BY country
ORDER BY articleCount DESC;";
                // Build a Command which holds the query and the location of the target server
                MySqlCommand cmd = new MySqlCommand(g, conn);
                // Retrieve the results into a DataReader
                MySqlDataReader rdr = cmd.ExecuteReader();
                // Output the header from the DataReader
                chatResult += String.Format("{0}\t{1}", rdr.GetName(0), rdr.GetName(1)) + Environment.NewLine;
                // Loop through the rows of the DataReader to output the values from the DataReader
                while (rdr.Read())
                {
                    chatResult += String.Format("{0}\t{1}", rdr.GetString(0), rdr.GetInt32(1)) + Environment.NewLine;
                }
                // Close the DataReader
                rdr.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            textBox1.Text = chatResult;
            chatResult = "";
        }
        //SQL 6
        private void button16_Click(object sender, EventArgs e)
        {
            establishConnection();
            try
            {
                // Write (copy from queries folder) the query
                string g = @"-- 6.	Write a SQL query which produces a table containing the average news_guard_score for the data set.

SELECT ROUND(AVG(news_guard_score),3) AS `Average Score`
FROM news;";
                // Build a Command which holds the query and the location of the target server
                MySqlCommand cmd = new MySqlCommand(g, conn);
                // Retrieve the results into a DataReader
                MySqlDataReader rdr = cmd.ExecuteReader();
                // Output the header from the DataReader
                chatResult += rdr.GetName(0) + Environment.NewLine;
                // Loop through the rows of the DataReader to output the values from the DataReader
                while (rdr.Read())
                {
                    rdr.GetDecimal(0).ToString("N3");
                    chatResult += String.Format("{0:N3}", rdr.GetDecimal(0)) + Environment.NewLine;
                }
                // Close the DataReader
                rdr.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            textBox1.Text = chatResult;
            chatResult = "";
        }
        //SQL 7
        private void button17_Click(object sender, EventArgs e)
        {
            establishConnection();
            try
            {
                // Write (copy from queries folder) the query
                string g = @"-- 7.	Write a SQL query which produces a table containing for each month, 
-- the name of the month, the number of articles released in that month, 
-- the overall number of articles released, and the percentage of the overall number of articles released in that month.  

SELECT month, numArticles, overall, ROUND(100*numArticles/overall,3) AS percentage
FROM
(
SELECT month, monthnum, COUNT(publish_date) AS numArticles, overallCount AS overall
FROM
(
SELECT DATE_FORMAT(STR_TO_DATE(publish_date, '%m/%d/%y'), '%M') AS month, 
       DATE_FORMAT(STR_TO_DATE(publish_date, '%m/%d/%y'), '%m') AS monthnum,
	   publish_date
FROM news
) AS T1
JOIN
(
SELECT COUNT(*) overallCount FROM news
) AS T2
GROUP BY month, monthnum, overallCount
) AS T3
ORDER BY monthnum;
";
                // Build a Command which holds the query and the location of the target server
                MySqlCommand cmd = new MySqlCommand(g, conn);
                // Retrieve the results into a DataReader
                MySqlDataReader rdr = cmd.ExecuteReader();
                // Output the header from the DataReader
                chatResult += String.Format("{0}\t{1}\t{2}\t{3}", rdr.GetName(0), rdr.GetName(1), rdr.GetName(2), rdr.GetName(3)) + Environment.NewLine;
                // Loop through the rows of the DataReader to output the values from the DataReader
                while (rdr.Read())
                {
                    chatResult += String.Format("{0}\t{1}\t{2}\t{3}", rdr.GetString(0), rdr.GetInt32(1), rdr.GetInt32(2), rdr.GetDecimal(3)) + Environment.NewLine;
                }
                // Close the DataReader
                rdr.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            textBox1.Text = chatResult;
            chatResult = "";
        }
        //SQL 8
        private void button18_Click(object sender, EventArgs e)
        {
            establishConnection();
            try
            {
                // Write (copy from queries folder) the query
                string g = @"-- 8.	Write a SQL query which produces a table containing the publisher names, 
-- and the percentage of articles for which are marked as reliable (1) among the articles published by that publisher.

SELECT publisher, ROUND(AVG(reliability)*100, 3) AS percentage
FROM news
JOIN publisher_table
USING (publisher_id)
GROUP BY publisher
ORDER BY percentage DESC, publisher;
";
                // Build a Command which holds the query and the location of the target server
                MySqlCommand cmd = new MySqlCommand(g, conn);
                // Retrieve the results into a DataReader
                MySqlDataReader rdr = cmd.ExecuteReader();
                // Output the header from the DataReader
                chatResult += String.Format("{0}\t{1}", rdr.GetName(0), rdr.GetName(1)) + Environment.NewLine;
                // Loop through the rows of the DataReader to output the values from the DataReader
                while (rdr.Read())
                {
                    chatResult += String.Format("{0}\t{1}", rdr.GetString(0), rdr.GetDecimal(1)) + Environment.NewLine;
                }
                // Close the DataReader
                rdr.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            textBox1.Text = chatResult;
            chatResult = "";
        }
        //SQL 9
        private void button19_Click(object sender, EventArgs e)
        {
            establishConnection();
            try
            {
                // Write (copy from queries folder) the query
                string g = @"-- 9.	Write a SQL query which produces a table containing unique countries and their average news_guard_score.

SELECT country, ROUND(AVG(news_guard_score),3) AS avg_news_score
FROM news
JOIN country_table
USING (country_id)
GROUP BY country
ORDER BY AVG(news_guard_score) DESC, country ASC;
";
                // Build a Command which holds the query and the location of the target server
                MySqlCommand cmd = new MySqlCommand(g, conn);
                // Retrieve the results into a DataReader
                MySqlDataReader rdr = cmd.ExecuteReader();
                // Output the header from the DataReader
                chatResult += String.Format("{0}\t{1}", rdr.GetName(0), rdr.GetName(1)) + Environment.NewLine;
                // Loop through the rows of the DataReader to output the values from the DataReader
                while (rdr.Read())
                {
                    rdr.GetFloat(1).ToString("N3");
                    chatResult += String.Format("{0}\t{1:N3}", rdr.GetString(0), rdr.GetFloat(1)) + Environment.NewLine;
                }
                // Close the DataReader
                rdr.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            textBox1.Text = chatResult;
            chatResult = "";
        }
        //SQL 10
        private void button20_Click(object sender, EventArgs e)
        {
            establishConnection();
            try
            {
                // Write (copy from queries folder) the query
                string g = @"-- 10.	Write a SQL query linking each author to their probable political bias, based on the articles they’ve written.  
-- The table should contain three columns, the author name, the political bias, and the count of how many articles that author has published with that bias.  
-- Order the results alphabetically by author name, from greatest number of articles to least, and alphabetically by bias in the case of a tie.

SELECT author, political_bias, COUNT(*) AS numArticles
FROM news
JOIN news_authors
USING (news_id)
JOIN author_table
USING (author_id)
JOIN political_bias_table
USING (political_bias_id)
GROUP BY author, political_bias
ORDER BY author, COUNT(*) DESC, political_bias;
";
                // Build a Command which holds the query and the location of the target server
                MySqlCommand cmd = new MySqlCommand(g, conn);
                // Retrieve the results into a DataReader
                MySqlDataReader rdr = cmd.ExecuteReader();
                // Output the header from the DataReader
                chatResult += String.Format("{0}\t{1}\t{2}", rdr.GetName(0), rdr.GetName(1), rdr.GetName(2)) + Environment.NewLine;
                // Loop through the rows of the DataReader to output the values from the DataReader
                while (rdr.Read())
                {
                    chatResult += String.Format("{0}\t{1}\t{2}", rdr.GetString(0), rdr.GetString(1), rdr.GetDecimal(2)) + Environment.NewLine;
                }
                // Close the DataReader
                rdr.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            textBox1.Text = chatResult;
            chatResult = "";
        }

        //Handling Input Data
        // -----------------
        // Functions to handle any input given by the user

        //File for F# textbox
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            filenameForFS = textBox2.Text;
        }
        //input textbox
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            inputChosen = textBox3.Text;
            inputInt = Int32.Parse(inputChosen);
        }
        //Server textbox
        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            server = textBox4.Text;
        }
        //port textbox
        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            port = textBox5.Text;
        }
        //username textbox
        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            username = textBox6.Text;
        }
        //password textbox
        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            password = textBox7.Text;
        }
        //database textbox
        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            database2 = textBox8.Text;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
