﻿using Advent.Common.Interop;
using Advent.Common.IO;
using Advent.Common.UI;
using Advent.MediaCenter;
using Advent.MediaCenter.StartMenu.OEM;
using Advent.VmcExecute;
using Advent.VmcStudio;
using Advent.VmcStudio.StartMenu;
using Advent.VmcStudio.StartMenu.Presenters;
using Microsoft.MediaCenter;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Advent.VmcStudio.StartMenu.Views
{
    public partial class EntryPointDocumentView : System.Windows.Controls.UserControl, IComponentConnector, IStyleConnector
    {
        // Methods
        public EntryPointDocumentView()
        {
            this.InitializeComponent();
        }

        private void AddDvdButtonClick(object sender, RoutedEventArgs e)
        {
            DriveInfo dataContext = (DriveInfo)((FrameworkElement)sender).DataContext;
            MediaInfo media = new MediaInfo
            {
                Url = string.Format("DVD://{0}:/video_ts", dataContext.Name.Substring(0, 1)),
                MediaType = Microsoft.MediaCenter.MediaType.Dvd
            };
            this.Document.Presenter.Media.Add(MediaInfoPresenter.Create(media));
        }

        private void AddKey(string message, IList<Keys> keys)
        {
            KeyListenerWindow window = new KeyListenerWindow
            {
                Owner = this.GetAncestor<Window>(),
                Message = message
            };
            window.ShowDialog();
            if ((window.Key != Keys.None) && !keys.Contains(window.Key))
            {
                keys.Add(window.Key);
            }
        }


        private ImageSource BrowseForImage()
        {
            string imageFile = VmcStudioUtil.GetImageFile();
            if (imageFile != null)
            {
                MemoryStream bitmapStream = new MemoryStream(File.ReadAllBytes(imageFile));
                return BitmapFrame.Create(bitmapStream);
            }
            return null;
        }

        private void BrowseImageClick(object sender, RoutedEventArgs e)
        {
            ImageSource source = this.BrowseForImage();
            if (source != null)
            {
                this.Document.Presenter.Image = source;
                this.Document.Presenter.IsImageAutoGenerated = false;
            }
            e.Handled = true;
        }

        private void BrowseInactiveImageClick(object sender, RoutedEventArgs e)
        {
            ImageSource source = this.BrowseForImage();
            if (source != null)
            {
                this.Document.Presenter.InactiveImage = source;
                this.Document.Presenter.IsInactiveImageAutoGenerated = false;
            }
            e.Handled = true;
        }

        private void ClearImageClick(object sender, RoutedEventArgs e)
        {
            this.Document.Presenter.IsImageAutoGenerated = true;
            this.UpdateAutoImages();
        }

        private void ClearInactiveImageClick(object sender, RoutedEventArgs e)
        {
            this.Document.Presenter.IsInactiveImageAutoGenerated = true;
            this.UpdateAutoImages();
        }

        private void CloseKeysAdd(object sender, RoutedEventArgs e)
        {
            this.AddKey("Press the key you want to close the application now.", this.Document.Presenter.CloseKeys);
        }

        private void DeleteCloseKey_Click(object sender, RoutedEventArgs e)
        {
            FrameworkElement element = sender as FrameworkElement;
            Keys dataContext = (Keys)element.DataContext;
            this.Document.Presenter.CloseKeys.Remove(dataContext);
        }

        private void DeleteKillKey_Click(object sender, RoutedEventArgs e)
        {
            FrameworkElement element = sender as FrameworkElement;
            Keys dataContext = (Keys)element.DataContext;
            this.Document.Presenter.KillKeys.Remove(dataContext);
        }

        private void DeleteMediaCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = this.mediaList.SelectedItems.Count > 0;
            e.Handled = true;
        }

        private void DeleteMediaExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            foreach (MediaInfoPresenter presenter in this.mediaList.SelectedItems.OfType<MediaInfoPresenter>().ToList<MediaInfoPresenter>())
            {
                this.Document.Presenter.Media.Remove(presenter);
            }
            e.Handled = true;
        }

        private void ExecutionUrlUpdated(object sender, RoutedEventArgs e)
        {
            this.UpdateAutoImages();
        }

        internal static EntryPointDocument GetOpenDocument(Advent.MediaCenter.StartMenu.OEM.EntryPoint entryPoint)
        {
            return Enumerable.FirstOrDefault<EntryPointDocument>(VmcStudioUtil.Application.Documents.OfType<EntryPointDocument>(), (Func<EntryPointDocument, bool>)(o => (o.Presenter.Model == entryPoint)));
        }

        private void InsertAudioExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            this.InsertResource(VmcStudioUtil.GetAudioFiles(), MediaType.Audio);
            e.Handled = true;
        }

        private void InsertImageExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            this.InsertResource(VmcStudioUtil.GetImageFiles(), MediaType.Video);
            e.Handled = true;
        }

        private void InsertResource(string[] files, MediaType mediaType)
        {
            if (files != null)
            {
                foreach (string str in files)
                {
                    MediaInfo media = new MediaInfo
                    {
                        MediaType = new MediaType?(mediaType),
                        Url = str
                    };
                    this.Document.Presenter.Media.Add(MediaInfoPresenter.Create(media));
                }
            }
        }

        private void InsertVideoExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            this.InsertResource(VmcStudioUtil.GetVideoFiles(), MediaType.Video);
            e.Handled = true;
        }

        internal static bool IsDocumentOpen(Advent.MediaCenter.StartMenu.OEM.EntryPoint entryPoint)
        {
            return (GetOpenDocument(entryPoint) == null);
        }

        private void KillKeysAdd(object sender, RoutedEventArgs e)
        {
            this.AddKey("Press the key you want to kill the application now.", this.Document.Presenter.KillKeys);
        }

        internal static void OpenDocument(Advent.MediaCenter.StartMenu.OEM.EntryPoint entryPoint)
        {
            EntryPointDocument openDocument = GetOpenDocument(entryPoint);
            if (openDocument == null)
            {
                openDocument = new EntryPointDocument(entryPoint);
                VmcStudioUtil.Application.Documents.Add(openDocument);
            }
            VmcStudioUtil.Application.SelectedDocument = openDocument;
        }

        private void SaveCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = this.Document.IsDirty;
            e.Handled = true;
        }

        private void SaveExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            this.Document.Save();
            e.Handled = true;
        }

        private void TargetPageSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.UpdateAutoImages();
        }

        private void UpdateAutoImages()
        {
            if (this.Document.Presenter.IsImageAutoGenerated)
            {
                if (this.Document.Presenter.IsInactiveImageAutoGenerated)
                {
                    this.Document.Presenter.InactiveImage = null;
                }
                if (this.Document.Presenter.TargetPage != EntryPointPresenter.NoPage)
                {
                    this.Document.Presenter.Image = this.Document.Presenter.TargetPage.GetImage();
                    if (this.Document.Presenter.IsInactiveImageAutoGenerated)
                    {
                        this.Document.Presenter.InactiveImage = this.Document.Presenter.TargetPage.GetNonFocusImage();
                    }
                }
                else if (!string.IsNullOrEmpty(this.ExecutionUrlText.Text))
                {
                    try
                    {
                        this.Document.Presenter.Image = Shell.GenerateThumbnail(this.ExecutionUrlText.Text);
                    }
                    catch (Exception exception)
                    {
                        Trace.TraceError(exception.ToString());
                    }
                    this.Document.Presenter.InactiveImage = null;
                }
                else if (this.Document.Presenter.Media.Count > 0)
                {
                    MediaInfoPresenter presenter = this.Document.Presenter.Media.First<MediaInfoPresenter>();
                    if (((MediaType)presenter.MediaInfo.MediaType) != MediaType.Dvd)
                    {
                        this.Document.Presenter.Image = presenter.Image;
                    }
                    else
                    {
                        string uri = "res://ehres!STARTMENU.QUICKLINK.PLAYDVD.FOCUS.PNG";
                        string str2 = "res://ehres!STARTMENU.QUICKLINK.PLAYDVD.NOFOCUS.PNG";
                        this.Document.Presenter.Image = MediaCenterUtil.GetImageResource(VmcStudioUtil.Application.CommonResources.LibraryCache, uri);
                        if (this.Document.Presenter.IsInactiveImageAutoGenerated)
                        {
                            this.Document.Presenter.InactiveImage = MediaCenterUtil.GetImageResource(VmcStudioUtil.Application.CommonResources.LibraryCache, str2);
                        }
                    }
                }
                else
                {
                    this.Document.Presenter.Image = null;
                }
            }
        }

        private void UserControl_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            NotifyCollectionChangedEventHandler handler = null;
            if (this.Document.Presenter.IsVmcExecute)
            {
                if (handler == null)
                {
                    handler = (_sender, _e) => this.UpdateAutoImages();
                }
                this.Document.Presenter.Media.CollectionChanged += handler;
            }
        }

        // Properties
        internal EntryPointDocument Document
        {
            get
            {
                return (EntryPointDocument)base.DataContext;
            }
        }

    }

}
