using Lime.Messaging.Contents;
using Lime.Protocol;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlipSDKHelperLibrary
{
    
    public static class BlipSDKHelper
    {


        public static PlainText CreateText(string text)
        {
            var document = new PlainText();
            document.Text = text;
            return document;
        }

        public static DocumentCollection CreateCarroussel(List<MediaLink> content, List<CarrousselButton> buttons)
        {

            var carroussel = new DocumentCollection();
            //contents.
            carroussel.Items = new DocumentSelect[content.Count];
            carroussel.ItemType = DocumentSelect.MediaType;

            //Para cada content existente.
            for (int i = 0; i < content.Count; i++)
            {

                var id_button = 0;

                var tmp = new DocumentSelect();
                tmp.Header = new DocumentContainer();
                tmp.Header.Value = new MediaLink();
                (tmp.Header.Value as MediaLink).Title = (content[i] as MediaLink).Title;
                (tmp.Header.Value as MediaLink).Text = (content[i] as MediaLink).Text;
                (tmp.Header.Value as MediaLink).PreviewUri = (content[i] as MediaLink).PreviewUri;
                (tmp.Header.Value as MediaLink).Uri = (content[i] as MediaLink).Uri;
                (tmp.Header.Value as MediaLink).Type = (content[i] as MediaLink).Type;

                var contentButtons = buttons.Select(b => b).Where(b => b.Container == i).OrderBy(b => b.Order);
                DocumentSelectOption[] tmp_buttons = new DocumentSelectOption[contentButtons.Count()];
                tmp_buttons = new DocumentSelectOption[contentButtons.Count()];


                foreach (var button in contentButtons)
                {

                    if (button.Type == ButtonType.Default)
                    {

                        DocumentSelectOption tmp_button = new DocumentSelectOption();
                        tmp_button.Order = button.Order;
                        tmp_button.Label = new DocumentContainer();
                        tmp_button.Label.Value = button.DocumentType;
                        tmp_button.Value = new DocumentContainer();
                        tmp_button.Value.Value = CreateText(button.Value);
                        tmp_buttons[id_button] = tmp_button;
                        id_button++;
                    }
                    else if (button.Type == ButtonType.Share)
                    {
                        DocumentSelectOption tmp_button = new DocumentSelectOption();
                        tmp_button.Order = button.Order;
                        tmp_button.Label = new DocumentContainer();
                        tmp_button.Label.Value = button.DocumentType;
                        tmp_buttons[id_button] = tmp_button;
                        id_button++;

                    }


                }
                tmp.Options = tmp_buttons;
                carroussel.Items[i] = tmp;
            }
            return carroussel;
        }

        public static MediaLink CreateCarrousselHeader(string title, string subtitle, string urlImage)
        {
            Uri imageUri = null;

            if (!urlImage.IsNullOrEmpty())
            {
                imageUri = new Uri(urlImage);

            }

            var document = new MediaLink();
            document.Title = title;
            document.Text = subtitle;
            document.Type = MediaType.Parse("image/jpeg");
            document.PreviewUri = imageUri;
            document.Uri = imageUri;

            return document;
        }

        public static CarrousselButton CreateCarrousselTextButton(string buttonName, string value, int Container, int Order)
        {
            CarrousselButton btn = new CarrousselButton();
            btn.Container = Container;
            btn.DocumentType = CreateText(buttonName);
            btn.Value = value;
            btn.Order = Order;
            btn.Type = ButtonType.Default;
            return btn;

        }
        public static CarrousselButton CreateCarrousselShareButton(int Container, int Order)
        {
            CarrousselButton btn = new CarrousselButton();
            btn.Container = Container;
            btn.DocumentType = new WebLink();
            (btn.DocumentType as WebLink).Uri = new Uri("share:");
            btn.Order = Order;
            btn.Type = ButtonType.Share;
            return btn;
        }

        public static CarrousselButton CreateCarrousselLinkButton(string buttonName, string url, int Container, int Order)
        {
            CarrousselButton btn = new CarrousselButton();
            btn.Container = Container;
            btn.DocumentType = CreateLink(url, buttonName);
            btn.Order = Order;
            btn.Type = ButtonType.Default;
            return btn;
        }

        public static MediaLink CreateImage(string urlImage, string previewUrlImage, string title, string text, string type)
        {
            var imageUri = new Uri(Uri.EscapeUriString(urlImage));
            var previewImageUri = new Uri(Uri.EscapeUriString(previewUrlImage));
            var document = new MediaLink();
            document.Title = title;
            document.Text = text;
            document.Type = MediaType.Parse(type);
            document.PreviewUri = previewImageUri;
            document.Uri = imageUri;

            return document;
        }

        public static MediaLink CreateImage(string urlImage, string previewUrlImage, string title, string text)
        {
            var imageUri = new Uri(Uri.EscapeUriString(urlImage));
            var previewImageUri = new Uri(Uri.EscapeUriString(previewUrlImage));
            var document = new MediaLink();
            document.Title = title;
            document.Text = text;
            document.Type = MediaType.Parse("image/*");
            document.PreviewUri = previewImageUri;
            document.Uri = imageUri;

            return document;
        }

        public static MediaLink CreateImage(string urlImage, string previewUrlImage, string title)
        {
            var imageUri = new Uri(Uri.EscapeUriString(urlImage));
            var previewImageUri = new Uri(Uri.EscapeUriString(previewUrlImage));
            var document = new MediaLink();
            document.Title = title;
            document.Text = "";
            document.Type = MediaType.Parse("image/*");
            document.PreviewUri = previewImageUri;
            document.Uri = imageUri;

            return document;
        }

        public static MediaLink CreateVideo(string urlVideo)
        {
            var videoUri = new Uri(Uri.EscapeUriString(urlVideo));
            var document = new MediaLink();
            document.Text = "";
            document.Type = MediaType.Parse("video/*");
            document.PreviewUri = videoUri;
            document.Uri = videoUri;

            return document;
        }

        public static MediaLink CreateVideo(string urlVideo, string title)
        {
            var videoUri = new Uri(Uri.EscapeUriString(urlVideo));
            var document = new MediaLink();
            document.Title = title;
            document.Text = "";
            document.Type = MediaType.Parse("video/*");
            document.PreviewUri = videoUri;
            document.Uri = videoUri;

            return document;
        }

        public static MediaLink CreateVideo(string urlVideo, string title, string text)
        {
            var videoUri = new Uri(Uri.EscapeUriString(urlVideo));
            var document = new MediaLink();
            document.Title = title;
            document.Text = text;
            document.Type = MediaType.Parse("video/*");
            document.PreviewUri = videoUri;
            document.Uri = videoUri;

            return document;
        }

        public static WebLink CreateImageWithLink(string urlImage, string _url, string title, string text)
        {
            var url = new Uri(_url);
            var previewUrl = new Uri(urlImage);

            var document = new WebLink();
            document.Title = title;
            document.Text = text;
            document.Uri = url;
            document.PreviewUri = previewUrl;

            return document;
        }

        public static WebLink CreateImageWithLink(string urlImage, string _url, string title)
        {
            var url = new Uri(_url);
            var previewUrl = new Uri(urlImage);

            var document = new WebLink();
            document.Title = title;
            document.Text = "";
            document.Uri = url;
            document.PreviewUri = previewUrl;

            return document;
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static WebLink CreateLink(string _url, string title)
        {
            var url = new Uri(_url);
            var document = new WebLink();
            document.Title = title;
            document.Text = "";
            document.Uri = url;
            return document;
        }

        public static Select CreateListOfOptions(string MenuText, Dictionary<string, string> options)
        {
            var document = new Select();
            document.Text = MenuText;
            document.Options = new SelectOption[options.Count];

            for (int i = 0; i < options.Count; i++)
            {
                document.Options[i] = new SelectOption();
                var button = options.ElementAt(i);
                document.Options[i].Text = button.Key;
                document.Options[i].Value = CreateText(button.Value);
                document.Options[i].Order = i;

            }

            return document;
        }

        public static Select CreateListOfOptions(string MenuText, Dictionary<string, string> options, SelectScope scope)
        {
            var document = new Select();
            document.Scope = scope;
            document.Text = MenuText;
            document.Options = new SelectOption[options.Count];

            for (int i = 0; i < options.Count; i++)
            {
                document.Options[i] = new SelectOption();
                var button = options.ElementAt(i);
                document.Options[i].Text = button.Key;
                document.Options[i].Value = CreateText(button.Value);
                document.Options[i].Order = i;

            }

            return document;
        }

        public static DocumentCollection CreateListOfDocuments(List<Document> content)
        {
            var document = new DocumentCollection();
            document.ItemType = DocumentContainer.MediaType;
            document.Items = new Document[content.Count()];
            document.Total = content.Count();
            for (int i = 0; i < content.Count(); i++)
            {
                document.Items[i] = new DocumentContainer();
                (document.Items[i] as DocumentContainer).Value = content[i];


            }

            return document;
        }

        public static DocumentSelect CreateQuickReply(string MenuText, List<DocumentSelectOption> options)
        {
            DocumentSelect document = new DocumentSelect();
            document.Scope = SelectScope.Immediate;
            document.Header = new DocumentContainer();
            document.Header.Value = new PlainText();
            (document.Header.Value as PlainText).Text = MenuText;
            //$"Onde você está? 🙂\n\n📨Envie seu CEP, endereço ou localização"

            DocumentSelectOption[] selectOption = new DocumentSelectOption[options.Count()];

            for (int i = 0; i < options.Count(); i++)
            {
                selectOption[i] = options[i];
            }

            document.Options = selectOption;

            return document;
        }

        public static DocumentSelectOption CreateQuickReplyDefaultButton(string text, string key)
        {
            var button = new DocumentSelectOption();
            button.Label = new DocumentContainer();
            button.Label.Value = CreateText(text);
            button.Value = new DocumentContainer();
            button.Value.Value = CreateText(key);

            return button;
        }


        public static DocumentSelectOption CreateQuickReplySendLocationButton()
        {
            var button = new DocumentSelectOption();
            button.Label = new DocumentContainer();
            button.Label.Value = new Input();
            (button.Label.Value as Input).Validation = new InputValidation();
            (button.Label.Value as Input).Validation.Rule = InputValidationRule.Type;
            (button.Label.Value as Input).Validation.Type = Location.MediaType;

            return button;
        }

        public static DocumentList CreateList(List<WebLink> content)
        {
            //List Facebook limit range is >=2 and <=4.
            if (content.Count > 4 || content.Count < 2)
            {
                return null;

            }
            var document = new DocumentList();

            document.Header = new DocumentContainer();
            document.Header.Value = content[0];

            document.Items = new DocumentContainer[content.Count - 1];
            for (int i = 1; i < content.Count; i++)
            {
                document.Items[i - 1] = new DocumentContainer();
                document.Items[i - 1].Value = content[i];
            }

            return document;
        }


    }



}
