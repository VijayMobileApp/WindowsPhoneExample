using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.IO;
using System.IO.IsolatedStorage;
using ReactiveUI.Xaml;
using ReactiveUI;
using MarkHeath.StarRating;

namespace NewExample.ViewModel
{
    public class IsolatedStorageExampleViewModel : ReactiveObject
    {
        public static string _userNameBox;
        public string userNameBox
        {
            get { return _userNameBox; }
            set { this.RaiseAndSetIfChanged(x => x.userNameBox, value); }
        }

        public static string _passwordBox;
        public string passwordBox
        {
            get { return _passwordBox; }
            set { this.RaiseAndSetIfChanged(x => x.passwordBox, value); }
        }

        public static string _folderNameBox;
        public string folderNameBox
        {
            get { return _folderNameBox; }
            set { this.RaiseAndSetIfChanged(x => x.folderNameBox, value); }
        }

        public static string _fileNameBox;
        public string fileNameBox
        {
            get { return _fileNameBox; }
            set { this.RaiseAndSetIfChanged(x => x.fileNameBox, value); }
        }

        public ReactiveAsyncCommand saveButton { get; set; }
        public ReactiveAsyncCommand createButton { get; set; }
        public ReactiveAsyncCommand deleteButton { get; set; }
        public ReactiveAsyncCommand createFileButton { get; set; }
        public ReactiveAsyncCommand deleteFileButton { get; set; }
        public ReactiveAsyncCommand deleteAllButton { get; set; }
        public ReactiveAsyncCommand viewButton { get; set; }
        public ReactiveAsyncCommand createInstance { get; set; }

        IsolatedStorageFile myIsolatedStorage = IsolatedStorageFile.GetUserStoreForApplication();

        private IsolatedStorageSettings settings = IsolatedStorageSettings.ApplicationSettings;

        public void instance()
        {
            IsolatedStorageFile myIsolatedStorage = IsolatedStorageFile.GetUserStoreForApplication();
           
            Console.WriteLine("New Instance Created..");
            
        }

        public IsolatedStorageExampleViewModel()
        {

            saveButton = new ReactiveAsyncCommand();
            saveButton.Subscribe(x =>
            {

                if (!string.IsNullOrEmpty(userNameBox))
                {
                    SaveStringObject(userNameBox);
                }
            });


            viewButton = new ReactiveAsyncCommand();
            viewButton.Subscribe(x => {
                if (!string.IsNullOrEmpty(userNameBox))
                {
                    ViewStringObject(userNameBox);
                }
            });
            createButton = new ReactiveAsyncCommand();
            createButton.Subscribe(x =>
            {
                if (!string.IsNullOrEmpty(folderNameBox))
                    CreateDirectory(folderNameBox);
                else
                    MessageBox.Show("Please Enter the Folder name");
            });


            deleteButton = new ReactiveAsyncCommand();
            deleteButton.Subscribe(x =>
            {
                if (!string.IsNullOrEmpty(folderNameBox))
                    DeleteDirectory(folderNameBox);
                else
                    MessageBox.Show("Please Enter the Folder name");
            });

            createFileButton = new ReactiveAsyncCommand();
            createFileButton.Subscribe(x =>
            {
                if (!string.IsNullOrEmpty(fileNameBox) && !string.IsNullOrEmpty(folderNameBox))
                    CreateFile(folderNameBox, fileNameBox);
                else
                    MessageBox.Show("Please Enter the Folder name and File name");
            });

            deleteFileButton = new ReactiveAsyncCommand();
            deleteFileButton.Subscribe(x =>
            {
                if (!string.IsNullOrEmpty(fileNameBox) && !string.IsNullOrEmpty(folderNameBox))
                    Delete(folderNameBox, fileNameBox);
                else
                    MessageBox.Show("Please Enter the Folder name and File name");
            });

            
            deleteAllButton = new ReactiveAsyncCommand();
            deleteAllButton.Subscribe(x =>
            {
                if (MessageBox.Show("Want to Erase All the File", "Warning..!!", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
                    //myIsolatedStorage.Remove();
                myIsolatedStorage.Dispose();
            });

            createInstance = new ReactiveAsyncCommand();
            createInstance.Subscribe(x => {
                if (!myIsolatedStorage.Equals(null))
                    instance();
            });
        }


        public void SaveStringObject(string email)
        {
            settings.Add("myemail", email);
            MessageBox.Show("Saved");
        }

        public void ViewStringObject(string email)
        {
            if (settings.Contains("myemail"))
            {
                //Retrieve email Data
                MessageBox.Show(settings["myemail"].ToString());
                //MessageBox.Show(settings.Values.ToString());
            }
        }

        public void CreateFile(string folder, string fileName)
        {
            try
            {
                string path = folder + "\\" + fileName + ".txt";
                StreamWriter writeFile;
                if (myIsolatedStorage.DirectoryExists(folder))
                {
                    if (!myIsolatedStorage.FileExists(path))
                    {
                        writeFile = new StreamWriter(new IsolatedStorageFileStream(path, FileMode.CreateNew, myIsolatedStorage));
                        MessageBox.Show("File is Created..!!");
                        writeFile.Close();
                    }
                    else
                        MessageBox.Show("Already this file is exists");
                }
                else
                {
                    myIsolatedStorage.CreateDirectory(folder);
                    writeFile = new StreamWriter(new IsolatedStorageFileStream(path, FileMode.CreateNew, myIsolatedStorage));
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void Delete(string folder, string fileName)
        {
            try
            {
                //string path = folder + "\\" + fileName + ".txt";
                string delPath = "/"+folder + "/" + fileName + ".txt";
                MessageBox.Show(delPath);
                if (myIsolatedStorage.DirectoryExists(folder))
                {
                    if (myIsolatedStorage.FileExists(delPath))
                    {
                        using (myIsolatedStorage = IsolatedStorageFile.GetUserStoreForApplication())
                        {
                            myIsolatedStorage.DeleteFile(delPath);
                            MessageBox.Show("File is Deleted..!!");
                        }
                    }
                    else
                        MessageBox.Show("There is no file is exists");
                }
                else
                {
                    MessageBox.Show("There is no Folder is exists");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void CreateDirectory(string directoryName)
        {
            try
            {
                if (!string.IsNullOrEmpty(directoryName) && !myIsolatedStorage.DirectoryExists(directoryName))
                {
                    myIsolatedStorage.CreateDirectory(directoryName);
                    MessageBox.Show("Created..!!");
                }
                else
                {
                    MessageBox.Show("Already Exist..!!");
                }
            }
            catch (Exception ex)
            {
                // handle the exception
            }
        }

        public void DeleteDirectory(string directoryName)
        {
            try
            {
                if (!string.IsNullOrEmpty(directoryName) && myIsolatedStorage.DirectoryExists(directoryName))
                {
                    myIsolatedStorage.DeleteDirectory(directoryName);
                    MessageBox.Show("Deleted..!!");
                }
                else
                {
                    MessageBox.Show("No Folder Exist with this name : " + directoryName);
                }
            }
            catch (Exception ex)
            {
                // handle the exception
            }
        }



    }
}
