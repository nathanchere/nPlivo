# nPlivo
### A more user-friendly .NET interface for the Plivo API

As nFMOD is for FMOD, this is intended as a more '.NET-feeling' library for the Plivo API than the official [plivo-dotnet](https://github.com/plivo/plivo-dotnet) library.

A very simple example which hopefully highlights the motivation for this library is sending an SMS. Assume `AuthToken` and `AuthId` are declared as per your Plivo account, the plivo-dotnet code for sending an SMS is:

```C#
var client = new Plivo.API.RestAPI(AuthId, AuthToken);
client.send_message(new Dictionary<string, string>(){
    { "src", "11212121211" },
    { "dst", "12212121211" },
    { "text", "Hi, text from Plivo." },
});
```

Compare this to the comparitive code in plivo-dotnet:

```C#
var client = new nPlivo.Client(AuthId, AuthToken);
client.SendSms("+123456789", "+01122334455", "Hello, World!");
```

If you see nothing wrong with the plivo-dotnet approach, please by all means use it as it is a far more thorough implementation of the Plivo API than I ever intend to offer. If things like magic-string dictionary parameters and silently swallowed exceptions make you cringe anywhere near as much as I do, you might prefer nPlivo. 

At this point in time nPlivo focuses solely on the Plivo REST API. If you want a helper library for working with Plivo's XML API you will still need to refer to the official [plivo-dotnet](https://github.com/plivo/plivo-dotnet).

[![Send me a tweet](http://nathanchere.github.io/twitter_tweet.png)](https://twitter.com/intent/tweet?screen_name=nathanchere "Send me a tweet") [![Follow me](http://nathanchere.github.io/twitter_follow.png)](https://twitter.com/intent/user?screen_name=nathanchere "Follow me")

## Documentation

Compared to the plivo-dotnet library, nPlivo is intended to be entirely self-documenting. In the event that you feel its usage isn't obvious enough and it warrants proper documentation, please let me know.


## Status

Branch | Status | Download | Description
------|-----|------|--------
master | N/A | [.zip](https://github.com/nathanchere/nPlivo/archive/master.zip) | for those who want to live on the bleeding edge
stable | N/A | [.zip](https://github.com/nathanchere/nPlivo/archive/stable.zip) | latest released/numbered code

*CI generously provided by [Appveyor](http://appveyor.com)*

How I approach my public projects is explained on [my github home page](http://nathanchere.github.io).

## Release history

####vAlpha (2014-06-14)

* initial release to GitHub

#### vTODO (one day)

* whatever I feel like

## Credits / thanks

* [Plivo](http://plivo.com/): for the underlying Plivo service and plivo-dotnet library which has been used as a reference implementation whilst developing nPlivo. 