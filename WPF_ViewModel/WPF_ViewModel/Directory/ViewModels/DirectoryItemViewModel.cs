
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace WPFApp_2
{
    /// <summary>
    /// view model for each directory item
    /// </summary>
    public class DirectoryItemViewModel : BaseViewModel
    {
        //type of item
        public DirectoryItemType Type { get; set; }

        //full path
        public string FullPath { get; set; }

        //name of the directory item
        public string Name { get { return this.Type == DirectoryItemType.Drive ? this.FullPath : DirectoryStructure.GetFileFolderName(this.FullPath); } }

        //list of children inside item
        public ObservableCollection<DirectoryItemViewModel> Children { get; set; }

        //asks if view can expand, returns true if not a file
        public bool CanExpand { get { return this.Type != DirectoryItemType.File; } }

        //see if view has been expanded
        public bool IsExpanded
        {
            get
            {
                //get count of children that arent null (dummy item)
                return this.Children?.Count(f => f != null) > 0;
            }
            set
            {
                //if UI says expand
                if (value == true)
                    //find all children
                    Expand();
                else
                    this.ClearChildren();
            }
        }


        //expands directory
        private void Expand()
        {
            if (this.Type == DirectoryItemType.File)
                return;

            var children = DirectoryStructure.GetDirectoryContent(this.FullPath);

            this.Children = new ObservableCollection<DirectoryItemViewModel>(
                                    children.Select(content => new DirectoryItemViewModel(content.FullPath, content.Type)));
                    }
        
        //removing all children on lists, adds dummy icon to show expand icon
        private void ClearChildren()
        {
            this.Children = new ObservableCollection<DirectoryItemViewModel>();

            //show expand arrow if not a file
            if (this.Type != DirectoryItemType.File)
                this.Children.Add(null);
        }

        //*********
        //commands
        //********

        //command to expand this item
        public ICommand ExpandCommand { get; set; }


        #region Constructor

        //default constructor
        public DirectoryItemViewModel(string fullPath, DirectoryItemType type)
        {
            //create commands
            this.ExpandCommand = new RelayCommand(Expand);

            this.FullPath = fullPath;
            this.Type = type;
        }

        #endregion
    }
}
