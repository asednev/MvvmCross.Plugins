using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Cirrious.CrossCore.Droid.Platform;
using System.IO;
using Android.Webkit;
using System.Diagnostics;
using Cirrious.CrossCore;

namespace dESCO.MvvmCross.Plugins.DocumentDisplayer.Droid
{
    public class MvxDocumentDisplayerTask : MvxAndroidTask, IMvxDocumentDisplayerTask
    {
        private Action m_complete;
        private Action m_failed;
        private string m_path;

        public void DisplayDocument(string extension, byte[] document, Action complete, Action failed)
        {
            m_complete = complete;
            m_failed = failed;

            var path = Path.Combine(Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryDownloads).AbsolutePath, "escmobile." + extension);
            m_path = path;

            if (System.IO.File.Exists(path))
            {
                Console.WriteLine("File already exists " + path);
                try
                {
                    System.IO.File.Delete(path);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Failed to delete: " + ex.Message);
                }
            }

            try
            {
                System.IO.File.WriteAllBytes(path, document);

                string szContentType;

                if (MimeTypeMap.Singleton.HasExtension(extension))
                {
                    szContentType = MimeTypeMap.Singleton.GetMimeTypeFromExtension(extension);
                }
                else
                {
                    szContentType = string.Empty;
                }

                Android.Net.Uri uri = Android.Net.Uri.Parse("file://" + path);

                var intent = new Intent(Intent.ActionView);

                if (!string.IsNullOrEmpty(szContentType))
                    intent.SetDataAndType(uri, szContentType);
                else
                    intent.SetData(uri);

                try
                {
                    StartActivityForResult(0, intent);
                }
                catch (Exception)
                {
                    throw;
                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);

                if (m_failed != null)
                    m_failed.Invoke();

                return;
            }

        }

        protected override void ProcessMvxIntentResult(Cirrious.CrossCore.Droid.Views.MvxIntentResultEventArgs result)
        {
            if (result.RequestCode == 0)
            {
                try
                {
                    System.IO.File.Delete(m_path);
                }
                catch (Exception ex) 
                {
                    Trace.WriteLine("Exception while deleting the file: " + ex.Message);
                }

                if (m_complete != null)
                    m_complete.Invoke();
            }
            else
                base.ProcessMvxIntentResult(result);
        }
    }
}