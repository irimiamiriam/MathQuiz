using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MathQuiz
{
    public partial class MathQuiz : Form
    {  
        Random rnd = new Random();
        int add1, add2, min, sub, mult1,mult2, div1,div2, timeleft;

        private void timer_Tick(object sender, EventArgs e)
        {
           
            if(CheckTheAnswer())
            {
                timer.Stop();
                MessageBox.Show("You got all the answers right!", "Congratulations!");
                start.Enabled= true;
            }
            else if (timeleft > 0) { timeleft--; time.Text = timeleft + " seconds";  }
            else
            {
                timer.Stop();
                time.Text = "Time's up!!";
                MessageBox.Show("You didn't finish in time.", "Sorry!");
                sum.Value = add1 + add2;
                difference.Value = min - sub;
                product.Value = mult1 * mult2;
                quotient.Value = div1 / div2;
                start.Enabled = true;
            }
        }

        private bool CheckTheAnswer()
        {
            if ((add1 + add2 == sum.Value)
                && (min - sub == difference.Value)
                && (mult1 * mult2 == product.Value)
                && (div1 / div2 == quotient.Value))
                return true;
            else
                return false;
        }
        private void start_Click(object sender, EventArgs e)
        {
            StartTheQuiz();
            start.Enabled = false;
        }

        public MathQuiz()
        {
            InitializeComponent();
        }

      public void StartTheQuiz()
        {
            add1 = rnd.Next(51);
            add2 = rnd.Next(51);
            min = rnd.Next(1, 101);
            sub = rnd.Next(1, min);
            mult1 = rnd.Next(1,11);
            mult2 = rnd.Next(1,11);
            div2 = rnd.Next(2, 11);
            int tq = rnd.Next(2, 11);
            div1 = tq * div2;
            plusL.Text = add1.ToString();
            plusR.Text = add2.ToString();
            minusL.Text = min.ToString();
            minusR.Text = sub.ToString();
            timesL.Text = mult1.ToString();
            timesR.Text = mult2.ToString();
            dividedL.Text = div1.ToString();
            dividedR.Text = div2.ToString();
            sum.Value = 0;
            difference.Value = 0;
            product.Value = 0;
            quotient.Value = 0;
            timeleft = 30;
            time.Text = "30 seconds";
            timer.Start();

        }
    }
}
