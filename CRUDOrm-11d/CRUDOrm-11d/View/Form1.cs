using CRUDOrm_11d.Controller;
using CRUDOrm_11d.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUDOrm_11d.View
{
    public partial class Form1 : Form
    {
        DogLogic dogsController = new DogLogic();
        BreedsLogic breedsController = new BreedsLogic();
        public Form1()
        {
            InitializeComponent();
        }

        private void LoadRecord(Dog dog)
        {
            txtId.BackColor = Color.White;
            txtId.Text = dog.Id.ToString();
            txtName.Text = dog.Name;
            txtAge.Text = dog.Age.ToString();
            cmbBreed.Text=dog.Breeds.ToString();    
        }
        private void ClearScreen()
        {
            txtId.Clear();
            txtName.Clear();
            txtAge.Clear();
            cmbBreed.Text = "";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            List<Breed> allBreads = breedsController.GetAllBreeds();
            cmbBreed.DataSource=allBreads;
            cmbBreed.DisplayMember = "Name";
            cmbBreed.ValueMember = "Id";
            //btnSelectAll_Click(sender,e);
        }

        private void btbAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.Text) || txtName.Text == "")
            {
                MessageBox.Show("Въведете данни!");
                txtName.Focus();
                return;
            }
            Dog newDog=new Dog();
            newDog.Age=int.Parse(txtAge.Text);
            newDog.Name=txtName.Text;
            newDog.BreedId = (int)cmbBreed.SelectedValue;
            dogsController.Create(newDog);
            MessageBox.Show("Добавен!");
            ClearScreen();
            //btnSelectAll_Click(sender, e);
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            List<Dog> allDogs = dogsController.GetAll();
            listBox1.Items.Clear();
            foreach (var item in allDogs)
            {
                listBox1.Items.Add($"{item.Id}. {item.Name}- {item.Age} years" +
                $"Breed: {this.blbBreed.Name}");
            }
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            int findId = 0;
            if (string.IsNullOrEmpty(txtId.Text) || txtId.Text.All(char.IsDigit))
            {
                MessageBox.Show("Въведи ид!");
                txtId.BackColor = Color.Red;
                txtId.Focus();
                return;
            }
            else
            {
                findId = int.Parse(txtId.Text);
            }
            Dog findDog = dogsController.Get(findId);
            if(findDog == null) 
            {
                MessageBox.Show("Не е намерено такоша ид.");
                txtId.BackColor = Color.Red;
                txtId.Focus();
                return;
            }
            LoadRecord(findDog);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int findId = 0;
            if (string.IsNullOrEmpty(txtId.Text) || txtId.Text.All(char.IsDigit))
            {
                MessageBox.Show("Въведи ид!");
                txtId.BackColor = Color.Red;
                txtId.Focus();
                return;
            }
            else
            {
                findId = int.Parse(txtId.Text);
            }

            if (string.IsNullOrEmpty(txtName.Text))
            {
                Dog findDog = dogsController.Get(findId);
                if (findDog == null)
                {
                    MessageBox.Show("Не е намерено такоша ид.");
                    txtId.BackColor = Color.Red;
                    txtId.Focus();
                    return;
                }
                LoadRecord(findDog);
            }
            else
            {
                Dog updateDog = new Dog();
                updateDog.Name=txtName.Text;
                updateDog.Age = int.Parse(txtAge.Text);
                //updateDog.Breeds =(int)cmbBreed.SelectedValue;
                //dogsController.Update(findId, updateDog);
            }
            btnSelectAll_Click(sender, e);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int findId = 0;
            if (string.IsNullOrEmpty(txtId.Text) || txtId.Text.All(char.IsDigit))
            {
                MessageBox.Show("Въведи ид!");
                txtId.BackColor = Color.Red;
                txtId.Focus();
                return;
            }
            else
            {
                findId = int.Parse(txtId.Text);
            }

            if (string.IsNullOrEmpty(txtName.Text))
            {
                Dog findDog = dogsController.Get(findId);
                if (findDog == null)
                {
                    MessageBox.Show("Не е намерено такоша ид.");
                    txtId.BackColor = Color.Red;
                    txtId.Focus();
                    return;
                }
                LoadRecord(findDog);
            }
            DialogResult answear = MessageBox.Show("Искате ли да изтриете записа?","Question",MessageBoxButtons.YesNo);
            if (answear == DialogResult.Yes)
            {
                dogsController.Delete(findId);
            }
            btnSelectAll_Click(sender, e);
        }
    }
}
