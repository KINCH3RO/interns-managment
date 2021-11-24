using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Word;
using Word = Microsoft.Office.Interop.Word;
using System.Reflection;
using System.IO;

namespace GestionnaireStagiaire
{
    class word
    {
        Word.Application wordApp = new Word.Application();
        Word.Document myWordDoc = null;
        public void FindAndReplace(Word.Application wordApp, object ToFindText, object replaceWithText)
        {
            

            object matchCase = true;
            object matchWholeWord = true;
            object matchWildCards = false;
            object matchSoundLike = false;
            object nmatchAllforms = false;
            object forward = true;
            object format = false;
            object matchKashida = false;
            object matchDiactitics = false;
            object matchAlefHamza = false;
            object matchControl = false;
            object read_only = false;
            object visible = true;
            object replace = 2;
            object wrap = 1;

            wordApp.Selection.Find.Execute(ref ToFindText,
                ref matchCase, ref matchWholeWord,
                ref matchWildCards, ref matchSoundLike,
                ref nmatchAllforms, ref forward,
                ref wrap, ref format, ref replaceWithText,
                ref replace, ref matchKashida,
                ref matchDiactitics, ref matchAlefHamza,
                ref matchControl);
        }

        
        //Creeate the Doc Method
        public void CreateWordDocument(object filename, object SaveAs, string[] tofind,string[] toreplace,bool print,int numberofcpy,IProgress<int> progress)
        {

           
           var myfile = File.Create(SaveAs.ToString());
            myfile.Close();
            
            object missing = Missing.Value;

            if (File.Exists((string)filename))
            {
                object readOnly = false;
                object isVisible = false;
                wordApp.Visible = false;

                myWordDoc = wordApp.Documents.Open(ref filename, ref missing, ref readOnly,
                                        ref missing, ref missing, ref missing,
                                        ref missing, ref missing, ref missing,
                                        ref missing, ref missing, ref missing,
                                        ref missing, ref missing, ref missing, ref missing);
                myWordDoc.Activate();
                int x = tofind.Length - 1;
                //find and replace
                for (int i = 0; i < tofind.Length; i++)
                {
                    this.FindAndReplace(wordApp, tofind[i], toreplace[i]);
                    progress.Report(i * 100 / x);
                    
                }
          

            }

            else
            {

            }

            //Save as
            myWordDoc.SaveAs2(ref SaveAs, ref missing, ref missing, ref missing,
                            ref missing, ref missing, ref missing,
                            ref missing, ref missing, ref missing,
                            ref missing, ref missing, ref missing,
                            ref missing, ref missing, ref missing);
            if (print)
            {
                for (int i = 0; i < numberofcpy; i++)
                {
                    myWordDoc.PrintOut();
                }
               
            }
            
            myWordDoc.Close();
            wordApp.Quit();
            
          
        }
        public void save()
        {
            myWordDoc.Save();
            myWordDoc.Close();
            wordApp.Quit();

        }



    }
}
