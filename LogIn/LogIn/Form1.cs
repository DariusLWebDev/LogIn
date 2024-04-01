using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LogIn
{
    public partial class Form1 : Form
    {
        public static IMongoClient client = new MongoClient("mongodb://localhost:27017");
        public static IMongoDatabase db = client.GetDatabase("UserSignup");
        public static IMongoCollection<Signup> coll = db.GetCollection<Signup>("mycoll");
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Signup user = new Signup(username.Text, email.Text, password.Text);
            coll.InsertOne(user);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

    }

    public class Signup
    {
        [BsonId]

        public ObjectId Id { get; set; }

        [BsonElement("username")]

        public string username { get; set; }

        [BsonElement("email")]

        public string email { get; set; }

        [BsonElement("password")]

        public string password { get; set; }

        public Signup(string username, string email, string password)
        {
            this.username = username;
            this.email = email;
            this.password = password;
        }
    }
}
