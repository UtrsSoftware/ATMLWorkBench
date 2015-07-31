using System.IO;
using ATMLCommonLibrary.managers;
using ATMLModelLibrary.model.uut;
using ATMLProject.managers;
using ATMLUtilitiesLibrary;

namespace ATMLProject.watchers
{
    public class UutWatcher : UTRSFileWatchable
    {
        public UutWatcher()
        {
            UTRSFileWatcher.Instance.WatchFile( this, ProjectManager.AtmlPath,
                                                "*" + ATMLContext.ATML_UUT_FILENAME_SUFFIX );
        }

        public void FileChanged( object sender, FileSystemEventArgs fileSystemEventArgs )
        {
            string fileName = fileSystemEventArgs.FullPath;
            UUTDescription uut = UutManager.GetUutFromFile( fileName );
            ProjectManager.ProcessUutChanges( uut );
        }

        public void FileCreated( object sender, FileSystemEventArgs fileSystemEventArgs )
        {
            string fileName = fileSystemEventArgs.FullPath;
            UUTDescription uut = UutManager.GetUutFromFile( fileName );
            ProjectManager.ProcessUutChanges( uut );
        }

        public void FileDeleted( object sender, FileSystemEventArgs fileSystemEventArgs )
        {
        }

        public void FileRenamed( object sender, FileSystemEventArgs fileSystemEventArgs )
        {
        }
        public void Close()
        {
            UTRSFileWatcher.Instance.ReleaseWatcher( this );
        }
    }
}