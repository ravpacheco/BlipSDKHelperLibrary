# BlipSDKHelperLibrary


Nuget Package:

https://www.nuget.org/packages/BlipSDKHelperLibrary/

To install the package:

PM> Install-Package BlipSDKHelperLibrary

---------------

# Using Examples:


1. Sending text
```C#
  var document = BlipSDKHelper.CreateText("... Inspiração, e um pouco de café! E isso me basta!");
  await _sender.SendMessageAsync(document, message.From, cancellationToken);
```

2. Sending Image/Video + text
 
 ```C#
//if you want to send an Image.
var document = BlipSDKHelper.CreateImage("https://dl.dropboxusercontent.com/s/99sw7vu788suww1/imagineFloor.jpg", "https://dl.dropboxusercontent.com/s/0u34yn7pj29ak1v/imagineFloorPreview.jpg", "ObligatoryTitle", "OptionalText");

//OR if you want to send a Video.
//var document = BlipSDKHelper.CreateVideo("https://dl.dropboxusercontent.com/s/jxy3sspxbl6ilan/John%20Lennon%20-%20Imagine.mp4", "title", "text");

await _sender.SendMessageAsync(document, message.From, cancellationToken);
```

3. Sending Weblink(Image with link)

```C#
var document = BlipSDKHelper.CreateImageWithLink("https://dl.dropboxusercontent.com/s/99sw7vu788suww1/imagineFloor.jpg", "https://dl.dropboxusercontent.com/s/0u34yn7pj29ak1v/imagineFloorPreview.jpg", "Obligatory text", "Non-Obligatory text");

await _sender.SendMessageAsync(document, message.From, cancellationToken);
```

4. Sending list of options (select)
```C#
//It is grouped by 3. 
Dictionary<string, string> buttons = new Dictionary<string, string>();
buttons.Add("Botao1", "Value1");
buttons.Add("Botao2", "Value2");
var document = BlipSDKHelper.CreateListOfOptions("Escolha uma opção:", buttons);

await _sender.SendMessageAsync(document, message.From, cancellationToken);
```

5. Creating Quickreply (With SendLocationButton)

```C#
List<DocumentSelectOption> buttons = new List<DocumentSelectOption>();
buttons.Add(BlipSDKHelper.CreateQuickReplyDefaultButton("botão1", "bla"));
buttons.Add(BlipSDKHelper.CreateQuickReplyDefaultButton("botão2", "bla2"));
buttons.Add(BlipSDKHelper.CreateQuickReplySendLocationButton());
var document = BlipSDKHelper.CreateQuickReply($"QuickReply Text", buttons);

await _sender.SendMessageAsync(document, message.From, cancellationToken);
```

6. Sending multiple things at the same time

```C#
List<Document> content = new List<Document>();
content.Add(BlipSDKHelper.CreateText("First message"));
content.Add(BlipSDKHelper.CreateImage("http://www.amor.blog.br/imagens/imagens-de-amor-imagem-15.jpg", "Title"));
content.Add(BlipSDKHelper.CreateVideo("https://dl.dropboxusercontent.com/s/g407mwt2agivwu6/filmejogo%2024%20B.mp4"));
var document = BlipSDKHelper.CreateListOfDocuments(content);

await _sender.SendMessageAsync(document, message.From, cancellationToken);
```

7. Carroussel (With ShareButton)

```C#
List<MediaLink> content = new List<MediaLink>();
content.Add(BlipSDKHelper.CreateCarrousselHeader("Title, Subtitle, Image and Buttons", "Image goes up above, Title goes above, Subtitle goes here and button goes below.", "http://www.w3schools.com/css/img_fjords.jpg"));
content.Add(BlipSDKHelper.CreateCarrousselHeader("Title, Subtitle and Button", "Title goes above, Subtitle goes here and button goes below.", ""));
content.Add(BlipSDKHelper.CreateCarrousselHeader("Title, Subtitle and Image", "Image goes up above, Title goes above and Subtitle goes here.", "http://www.w3schools.com/css/img_fjords.jpg"));
content.Add(BlipSDKHelper.CreateCarrousselHeader("Title, Image and Button: Image goes up above, Title goes here and button below", "", "http://www.w3schools.com/css/img_fjords.jpg"));
content.Add(BlipSDKHelper.CreateCarrousselHeader("Title and Image: Image goes up above, Title goes here", "", "http://www.w3schools.com/css/img_fjords.jpg"));
content.Add(BlipSDKHelper.CreateCarrousselHeader("Title and Subtitle", "Title goes above, Subtitle goes here", ""));
content.Add(BlipSDKHelper.CreateCarrousselHeader("Title and Button: Title goes here, button goes below", "", ""));

List<CarrousselButton> buttons = new List<CarrousselButton>();
buttons.Add(BlipSDKHelper.CreateCarrousselTextButton("First button: Text", "bla", 0, 0));
buttons.Add(BlipSDKHelper.CreateCarrousselLinkButton("Second button: Link", "http://www.w3schools.com/css/img_fjords.jpg", 0, 1));
buttons.Add(BlipSDKHelper.CreateCarrousselTextButton("Just a text","bla3", 1, 1));
buttons.Add(BlipSDKHelper.CreateCarrousselLinkButton("Redirect to link", "http://www.w3schools.com/css/img_fjords.jpg", 3, 1));
buttons.Add(BlipSDKHelper.CreateCarrousselLinkButton("Redirect to link","http://www.w3schools.com/css/img_fjords.jpg", 6, 1));
buttons.Add(BlipSDKHelper.CreateCarrousselLinkButton("Redirect to link", "http://www.facebook.com", 6, 2));
buttons.Add(BlipSDKHelper.CreateCarrousselShareButton(0, 2));

var document = BlipSDKHelper.CreateCarroussel(content, buttons);

await _sender.SendMessageAsync(document, message.From, cancellationToken);
```

8. Create List

```C#
var content = new List<WebLink>();
content.Add(BlipSDKHelper.CreateImageWithLink("http://www.jqueryscript.net/images/Simplest-Responsive-jQuery-Image-Lightbox-Plugin-simple-lightbox.jpg", "http://www.jqueryscript.net/images/Simplest-Responsive-jQuery-Image-Lightbox-Plugin-simple-lightbox.jpg", "Title", "Text"));
content.Add(BlipSDKHelper.CreateImageWithLink("http://www.jqueryscript.net/images/Simplest-Responsive-jQuery-Image-Lightbox-Plugin-simple-lightbox.jpg", "http://www.jqueryscript.net/images/Simplest-Responsive-jQuery-Image-Lightbox-Plugin-simple-lightbox.jpg", "Title", "Text"));

var document = BlipSDKHelper.CreateList(content);

await _sender.SendMessageAsync(document, message.From, cancellationToken);
```
