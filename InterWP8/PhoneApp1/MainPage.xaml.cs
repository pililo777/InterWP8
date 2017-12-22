using System;
using System.Linq;
using System.Windows;
using Microsoft.Phone.Controls;
using System.IO.IsolatedStorage;
using System.IO;
using Windows.Storage;
using System.Threading.Tasks;
using System.Diagnostics;
 



namespace CppWithWP {


      enum tipos_nodo {un_numero = (int) 1, desde, nombre_de_variable, 
			indice_strings, procedimiento, secuencia , imprimir, 
			suma, resta, multiplica, divide, si, mientras, asigna_num, asigna_alfa,
			mayorque, menorque, igualque, leer, leertexto, noigualque, menorigualque, mayorigualque, negativo,
			comparaliteral, imprimir_varios, imprimir_expresion, imprimir_literal, imprimir_var_alfa, 
			
			constante_literal, llamar, decimales, vacio }  ;




    public partial class MainPage : PhoneApplicationPage {

        bool editando = false;
        String localfolder = Windows.Storage.ApplicationData.Current.LocalFolder.Path;

        String[] constantes = new String[127];
        double[] var = new double[127];

        //StorageFolder storageFolder = KnownFolders.DocumentsLibrary;




        //    "C:\\Data\\Users\\Public\\Documents"


        public  MainPage() {
            InitializeComponent();
            String myFileName = String.Concat(localfolder, "\\test.txt");

           


            try
            {
                using (IsolatedStorageFile f = IsolatedStorageFile.GetUserStoreForApplication())
                {
                    //To read
                    using (StreamReader r = new StreamReader(f.OpenFile(myFileName, FileMode.Open)))
                    {
                        string text = r.ReadToEnd();
                        txtBlockAnswer.Text = text;

                    }
                }
            }

            catch (Exception ex) {
                Debug.WriteLine(ex.Message);
            }
                       
        }




        private void btnSubmit_Click(object sender, RoutedEventArgs e) {
            //byte[] resultados = null;

            
			String myFileName = String.Concat(localfolder, "\\test.txt");
           
            int numero;
            numero = Convert.ToInt16(txtBxString.Text);

				// std::wstring stlString = myFileName->Data();

             //CppWINRT.StringCharacterCounter sccMain = new CppWINRT.StringCharacterCounter();

            CppWINRT.clase1 variable1 = new CppWINRT.clase1();
            CppWINRT.ast ast1  ;



          
            int i;
            Double variable2 ;
            variable1.asignar_num(numero, "numerito");
            variable1.asignar_num(5, "numerito2");
            variable1.asignar_num(35, "numerito3");
            String xx = txtBxString.Text;


            variable2 = variable1.run(xx);	// 'ejecuta el programa INTER

            for (  i = 0; i < 127; i++) {

                constantes[i] = variable1.getconstante(i);
            
            }

            for (i = 0; i < 127; i++)
            {

                var[i] = variable1.getvar(i);

            }

            ast1 = variable1.getmainprogram();

            using (IsolatedStorageFile f = IsolatedStorageFile.GetUserStoreForApplication())
            {
                //To read
                // using (StreamReader r = new StreamReader(f.OpenFile(myFileName, FileMode.Open )))
                {
                   // string text = r.ReadToEnd();
                    string text2 = execut(ast1);
                    txtBlockAnswer.Text = text2;
                }
            }



            //txtBlockAnswer.Text = sccMain.GetLength(txtBxString.Text).ToString() + " characters were found in the string above";
            //System.IO.FileStream fs = System.IO.File.OpenRead(myFileName);
            //fs.Read(resultados, 0, 9999);
            //txtBlockAnswer.Text = System.Text.Encoding.UTF8.GetString  (resultados, 0, 9999);
        }

        
        private   async void    btnEdit_Click(object sender, RoutedEventArgs e)
        {
          //   String myFileName2 = String.Concat(localfolder, "\\p1.pr");
          

             if (!editando)
             {
                 txtBlockAnswer.Visibility = System.Windows.Visibility.Collapsed;
                 txtPrograma.Visibility = System.Windows.Visibility.Visible;
                 //txtPrograma.Text = 

                 //using (IsolatedStorageFile f = IsolatedStorageFile.GetUserStoreForApplication())
                 {

                     string  res = await  leer_fichero();

                     //using (StreamReader r = new StreamReader(f.OpenFile(myFileName2, FileMode.Open)))
                     //{
                     //    string text = r.ReadToEnd();
                      txtPrograma.Text = res;

                     //}

                     editando = true;
                 }
             }
             else
             {
                 editando = false;
                 
                 {

                     string res = await escribir_fichero(txtPrograma.Text.ToString());
                     txtBlockAnswer.Text = txtPrograma.Text;
                     txtBlockAnswer.Visibility = System.Windows.Visibility.Visible;
                     txtPrograma.Visibility = System.Windows.Visibility.Collapsed;
                     
                 }

             }
        }


        int nro_decimales = 0;
        int indice_ctr = 0;
        int[] counter1 = new int[20];
        StringWriter sw = new StringWriter();


string execut(CppWINRT.ast a)
{
CppWINRT.ast p;
//p = nuevonodo();

    tipos_nodo t;
    t = (tipos_nodo) a.Tipo;


p = a;
switch (t) {

	case tipos_nodo.decimales:

		nro_decimales =  ( (int) p.Nodo1.Numero );
		break;



	case tipos_nodo.secuencia:
 
		execut(p.Nodo1);
 
		execut(p.Nodo2);
		break;

	case tipos_nodo.imprimir_literal :
				sw.WriteLine(  constantes [(int)p.Nodo1.Numero] ) ;
                
				break;

	case tipos_nodo.imprimir_var_alfa:
		 
				sw.WriteLine(  constantes [ (int)   var  [(int)p.Nodo1.Numero]   ]) ;
				break;

	case tipos_nodo.imprimir_expresion :


		switch(nro_decimales ) {

			case 0:
				sw.WriteLine(  evalua(p.Nodo1) );
				break;

			 
			default:
                sw.WriteLine(  evalua(p.Nodo1));
				break;

		};

		break;



	case tipos_nodo.imprimir_varios:
		 
		execut(p.Nodo1);
		sw.WriteLine("\n");
		break;

	
	case tipos_nodo.llamar:
		//fprintf("\nllamar un procedimiento\n");
        //if (procedimientos[(int)p->nodo1->num] == NULL)
        //   {
        //       fprintf(fichero, "procedimiento no encontrado en linea: \n");
        //       getchar();
			   //exit (1);
           //}

        //execut ( procedimientos[ (int) (p->nodo1->num) ]  );
		//fprintf("volvemos del procedimiento\n\n");
        sw.WriteLine("orden llamar\n");
		break;

	case tipos_nodo.asigna_num:
	 
		var [(int)p.Nodo1.Numero] =  evalua(p.Nodo2);
		break;

	case tipos_nodo.asigna_alfa:
 
		var[(int)p.Nodo1.Numero] = p.Nodo2.Numero;
		break;

	case tipos_nodo.mientras:
 
		while ( evalua(p.Nodo1) == (double) 1   ) 
 
			execut(p.Nodo2);
 
 
		break;

	case tipos_nodo.leer:
 
		{
        // elnodo *pp;    
        // int inum = 0;
        //double fnum;
        //pp = p;
        //inum = (int)p->nodo1->num;
	 
        //scanf("%lf", &fnum );
        //var[inum] = fnum;
		}
		break;

	case tipos_nodo.leertexto:
 
		{
        //int indice;
        //elnodo * pp ;
	 
        //char texto[255]  ;
        ////pp = p;
        // getstring(texto); 
        // if (error_getstring )
        //     getstring (texto);
 
        //indice = (int)p->nodo1->num;
        //strcpy ( constantes [(int)var[indice]], texto);
		}
		break;

	case tipos_nodo.si:
	 
		if (evalua(p.Nodo1) > 0) {
			execut(p.Nodo2); }
		else
			if (p.Subnodos == 3) {
 
				execut(p.Nodo3);
			};
 
		
		break;

	case tipos_nodo.desde:
 
		{
		int x =  (int)p.Nodo1.Numero;
 
		indice_ctr++;
        var[x] = (int) evalua(p.Nodo2);
		counter1[indice_ctr] = (int) var[x]  ;

		for (counter1[indice_ctr]=counter1[indice_ctr]; counter1[indice_ctr] <= (int) evalua(p.Nodo3 ); counter1[indice_ctr]++)
			{
 
				var[x] = counter1[indice_ctr];
				execut(p.Nodo4 );
			}

		indice_ctr--;
		
		}
		
		break;


	default:
		break;

	}
return sw.ToString();
}

 


 double evalua(CppWINRT.ast p) {
 

	switch ((tipos_nodo)p.Tipo) {
	
	case tipos_nodo.indice_strings:    //una variable numerica
            return var[(int)p.Numero];
	
	case tipos_nodo.un_numero:
		return p.Numero ;     //un numero constante
 
	case tipos_nodo.resta:

        return evalua(p.Nodo1) - evalua(p.Nodo2);

	case tipos_nodo.suma:
        return evalua(p.Nodo1) + evalua(p.Nodo2);

	case tipos_nodo.multiplica:
        return evalua(p.Nodo1) * evalua(p.Nodo2);

	case tipos_nodo.divide:
		if (evalua(p.Nodo2) == 0 ) {
            return 0;
 
		}
       
		return evalua(p.Nodo1) / evalua(p.Nodo2) ;

	case tipos_nodo.mayorque:
		if (evalua(p.Nodo1) > evalua(p.Nodo2)) return 1; else return 0;

	case tipos_nodo.mayorigualque:
		if (evalua(p.Nodo1) >= evalua(p.Nodo2)) return 1; else return 0;

	case tipos_nodo.noigualque:
		if (evalua(p.Nodo1) != evalua(p.Nodo2)) return 1; else return 0;

	case tipos_nodo.menorque:
		if (evalua(p.Nodo1) < evalua(p.Nodo2)) return 1; else return 0;

	case tipos_nodo.igualque:
		if (evalua(p.Nodo1) == evalua(p.Nodo2)) return 1; else return 0;

	case tipos_nodo.menorigualque:
		if (evalua(p.Nodo1) <= evalua(p.Nodo2)) return 1; else return 0;

	case tipos_nodo.negativo:
		return  evalua(p.Nodo1 ) * (-1);

	case tipos_nodo.comparaliteral:

		{
 
            if (constantes[(int)var[(int)p.Nodo1.Numero]] == constantes [(int)p.Nodo2.Numero]) return 1; else return 0;
 
		}

	default:
        
		break;
 
	}
    return 0;
}


           

        static async Task<string> leer_fichero()
        {
            //var folder = Windows.ApplicationModel.Package.Current.InstalledLocation;
            //var file = await folder.GetFileAsync("sample.txt");
            //  var contents = await Windows.Storage.FileIO.ReadTextAsync(file);

            Windows.Storage.FileAttributes fileAttr;
            //long fileSize = -1;


            FileInfo info = new FileInfo("p1.pr");
            Debug.WriteLine("File size=" + info.Length);
            MessageBox.Show("file size: " + info.Length);
            
            string fileContent;
            StorageFile file = await StorageFile.GetFileFromApplicationUriAsync(new Uri(@"ms-appx:///p1.pr"));
            using (StreamReader sRead = new StreamReader(await file.OpenStreamForReadAsync()))
            {
                fileAttr = file.Attributes;
                

                fileContent = await sRead.ReadToEndAsync();
                sRead.Close();
            }

            return   fileContent  ;
            

        }

        static async Task<string> escribir_fichero(string fileContent)
        {
            //var folder = Windows.ApplicationModel.Package.Current.InstalledLocation;
            //var file = await folder.GetFileAsync("sample.txt");
            //  var contents = await Windows.Storage.FileIO.ReadTextAsync(file);

            try
            {
                StorageFile file = await StorageFile.GetFileFromApplicationUriAsync(new Uri(@"ms-appx:///p1.pr"));
                await file.DeleteAsync();
                //string filename = "p1.pr";
                //IsolatedStorageFile file2 = IsolatedStorageFile.GetUserStoreForApplication();
                //file2.DeleteFile(filename);

                MessageBox.Show("fichero p1.pr eliminado.");

            }

            catch (Exception ex) {

                MessageBox.Show("DELETE:" + ex.Message);

            }


            //aqui mal

            try
            {
                 System.Text.Encoding enc = new PhoneApp2.AsciiEncoding();
                StorageFolder folder = Windows.ApplicationModel.Package.Current.InstalledLocation;

                StorageFile file = await folder.CreateFileAsync("p1.pr", CreationCollisionOption.ReplaceExisting);

                StorageFile file2 = await StorageFile.GetFileFromApplicationUriAsync(new Uri(@"ms-appx:///p1.pr"));
                using (StreamWriter sRead = new StreamWriter(await file2.OpenStreamForWriteAsync() , enc   ))
                {
                    //await sRead.WriteAsync(fileContent);
                    fileContent = fileContent.Replace("\r\n", "\n");
                    fileContent = fileContent.Replace("\r", "\n");
                    sRead.Write(fileContent);
                    sRead.Close();
                }
            }

            catch (Exception ex) {
                MessageBox.Show("WRITE:" + ex.Message);
            }

            try
            {
                FileInfo info = new FileInfo("p1.pr");
                Debug.WriteLine("File size=" + info.Length);
                MessageBox.Show("file size: " + info.Length);
            }
            catch (Exception ex) {
                MessageBox.Show("FILESIZE:" + ex.Message);
            }

            return "";

        }


   }



}





            //Dim variable1 As New prueba.clase1		'ver CLASE1 en  main.cpp
            //Dim variable2 As Double


            //variable1.asignar_num(8, "numerito")
            //variable1.asignar_num(5, "numerito2")
            //variable1.asignar_num(35, "numerito3")

            //variable2 = variable1.run(TextBox2.Text.ToString)	'ejecuta el programa INTER

            //TextBox1.Text = System.IO.File.ReadAllText("c:\test.txt ")
            //TextBox1.Text &= vbCrLf
            //TextBox1.Text &= "Valor devuelto: " & Str(variable2) & vbCrLf
            //TextBox1.Text &= "VARIABLE x = " & variable1.buscar_valor("x") & vbCrLf
            //TextBox1.Text &= "VARIABLE y = " & variable1.buscar_valor("y") & vbCrLf
            //TextBox1.Text &= "VARIABLE z = " & variable1.buscar_valor("z") & vbCrLf
            //TextBox1.Text &= "VARIABLE numerito3 = " & variable1.buscar_valor("numerito3") & vbCrLf

/*
string fileContent;
StorageFile file = await StorageFile.GetFileFromApplicationUriAsync(new Uri(@"ms-appx:///example.txt"));
using (StreamReader sRead = new StreamReader(await file.OpenStreamForReadAsync()))
fileContent = await sRead.ReadToEndAsync();
*/
