FlashHelper
===========

A helper that wraps the TempData Dictionary so you can flash messages in Razor views

You can use any of the following methods in your controller:
```
this.FlashSuccess("success!");
this.FlashInfo("info!");
this.FlashWarning("warning!");
this.FlashError("error!");
```

Then, in your Razor view, use
```
@Html.Flash()
```

This will produce output like this:
```html
<div class="alert alert-success">success!</div>
<div class="alert alert-info">info!</div>
<div class="alert alert-warning">warning!</div>
<div class="alert alert-error">error!</div>
```

See Twitter Bootstrap for use of these CSS classes: http://www.tutorialspoint.com/bootstrap/bootstrap_alerts.htm