using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrinkDispenser
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int total;
        private void btn_cart_Click(object sender, EventArgs e)
        {
            int mango, papaya, woodapple, st_mango, st_papaya, st_woodapple, up_mango, up_papaya, up_woodapple;

            try 
            {
                mango = Convert.ToInt32(txt_mango.Text);
                papaya = Convert.ToInt32(txt_papaya.Text);
                woodapple = Convert.ToInt32(txt_woodapple.Text);

                st_mango = Convert.ToInt32(is_mango.Text);
                st_papaya = Convert.ToInt32(is_papaya.Text);
                st_woodapple = Convert.ToInt32(is_woodapple.Text);

                up_mango = Convert.ToInt32(Price_mango.Text);
                up_papaya = Convert.ToInt32(Price_papaya.Text);
                up_woodapple = Convert.ToInt32(Price_woodapple.Text);


                if (mango > st_mango | papaya > st_papaya | woodapple > st_woodapple)
                {
                    MessageBox.Show("Not enough stock", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    this.total = mango * up_mango + papaya * up_papaya + woodapple * up_woodapple;

                    is_mango.Text = (st_mango - mango).ToString();
                    is_papaya.Text = (st_papaya - papaya).ToString();
                    is_woodapple.Text = (st_woodapple - woodapple).ToString();

                    gb_cashier.Visible = true;

                    lbl_Total.Text = "Rs." + total.ToString();
                }
            }

            catch
            {
                MessageBox.Show("Enter the amount you need as whole numbers", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            txt_mango.Clear();
            txt_papaya.Clear();
            txt_woodapple.Clear();
        }

        private void btn_pay_Click(object sender, EventArgs e)
        {
            try 
            {
                int paid = Convert.ToInt32(txt_paid.Text);

                if (paid < this.total)
                {
                    MessageBox.Show("Please pay the total amount", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    lbl_balance.Text = (paid - this.total).ToString();
                    txt_mango.Clear();
                    txt_papaya.Clear();
                    txt_woodapple.Clear();
                }
            }
            catch
            {
                MessageBox.Show("Please pay as a whole number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
