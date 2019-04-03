﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using F5074.Winforms.MyResources;

namespace F5074.Winforms.TabFolder
{
    public partial class A_Enum : UserControl
    {
        private enum DBIndex
        {
              ORDER_QTY
            , END_DATE_TIME
            , PRODUCT_NAME
            , END_QTY
            , PROCESS_NAME
            , EQP_NO
            , CREATE_DATE_TIME
        };

        enum ClassType
        {
              A_DataTable
            , B_TreeList
            , C_ButtonImage
            , D_GridControl
            , E_TabControl
            , F_ButtonEdit
            , G_DateEditTab
            , H_GridCheckBoxInCell
        };

        public A_Enum()
        {
            InitializeComponent();
            MakeParameters();
            EnumTest();

        }

        private void EnumTest()
        {
            for (int x = 0; x < Enum.GetNames(typeof(ClassType)).Length; x++)
            {
                if (ClassType.B_TreeList == "B_TreeList".ToEnum<ClassType>())
                {
                    MessageBox.Show(Enum.GetNames(typeof(ClassType))[x].ToString());
                }

            }
        }

        private void MakeSentences()
        {
            string a = "this.txt";
            string b = ".EditValue = ";
            string d = ";";

            for (int x = 0; x < Enum.GetNames(typeof(DBIndex)).Length; x++)
            {
                string c = Enum.GetNames(typeof(DBIndex))[x].ToString();
                this.textBox1.AppendText(a + c + b + c + d + "\r\n");
                //this.textBox1.Text += a + c + b + c + d + "\r\n";
                //Console.WriteLine(a + c + b + c + d);
            }
        }

        private void MakeParameters()
        {
            // https://docs.microsoft.com/ko-kr/dotnet/framework/winforms/controls/how-to-put-quotation-marks-in-a-string-windows-forms
            string a = "parameters.Add(\u0022";
            string b = "\u0022, \u0022\u0022)";
            string d = ";";

            for (int x = 0; x < Enum.GetNames(typeof(DBIndex)).Length; x++)
            {
                string c = Enum.GetNames(typeof(DBIndex))[x].ToString();
                this.textBox1.AppendText(a + c + b + d + "\r\n");
                //this.textBox1.Text += a + c + b + c + d + "\r\n";
                //Console.WriteLine(a + c + b + c + d);
            }
        }
    }
}
