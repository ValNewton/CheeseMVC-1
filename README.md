# Class 9

[Class 9 Prep](http://education.launchcode.org/skills-back-end-csharp/videos/intro-to-mvc-viewmodels-1/)

**NOTE: I did not start/end with the Git branches specified in the prep work description. All of my code modifications may be found in the `class-9-prep` branch.**

# Class 8

[Class 8 Prep](http://education.launchcode.org/skills-back-end-csharp/videos/intro-to-mvc-models/)

**NOTE: I did not start/end with the Git branches specified in the prep work description. All of my code modifications may be found in the `class-8-prep` branch.**

# Class 5

[Class 5 Prep](http://education.launchcode.org/skills-back-end-csharp/class-prep/5/)

# Class 4

[Class 4 Prep](http://education.launchcode.org/skills-back-end-csharp/class-prep/4/)

## Intro to ASP.NET Core MVC: Views (Part 1)

- controller => C# class
- view => .cshtml file

By default, "views" (.cshtml files) are located: 

- `PROJECT/Views/[ControllerName]/[ActionName].cshtml`
- `PROJECT/Views/Shared/[ActionName].cshtml`

Razor templates (.cshtml) are similar to Jinja templates in Python *in that* they can contain both HTML markup *and* view logic.

`ViewData` is a specizlized `Dictionary` that acts as a "bucket" of data passed into the view.

To share a view across different controllers, put it in `/Views/Shared`.

C# code can be added to a view by prefixing it with an `@` symbol.

A default layout can be applied to all views by adding the file: `/Views/Shared/_Layout.cshtml`.

Changes to views do not require a server restart ("hot deployment").

## Intro to ASP.NET Core MVC: Views (Part 2)

Code blocks can be added to Razor views by preceeding them with the `@` symbol:

```cs
<ul>
    @foreach (string cheese in cheeses)
    {
        <li>@cheese</li>
    }
</ul>
```

It is generally *not* a good idea to create data in view files!

There are multiple ways to pass data to a view.

`ViewBag` is a "dynamic" object that can be assigned properties of any type that contain data for the view. This is very similar to, but not the same, as `ViewData`. (See: [ViewModel vs ViewData vs ViewBag vs TempData vs Session in MVC](http://www.mytecbits.com/microsoft/dot-net/viewmodel-viewdata-viewbag-tempdata-mvc))

Links (`<a>` tags) can use `asp-*` attributes to *generate* `href` values:

```html
<a asp-controller="Cheese" asp-action="Add">Add Cheese</a>
```

Static class properties can make data available to any *instance* of a class:

```cs
public class CheeseController : Controller
{
    // available to *all* instances of CheeseController;
    // all instances *share* this list
    private static List<string> cheeses = new List<string>();

    // created per-instance; each instance gets its own list
    private List<string> moreCheeses = new List<string>();
}
```

The `Controller.Redirect()` method returns a `RedirectResult`, which can be returned from a controller action method to take the user to some other route.

## Studio

**Routing parameters can be added to anchors using special MVC helper attributes.**

*In the controller:*

```cs
[Route("/cheese/remove/{cheeseName}")]
[HttpGet]
public IActionResult RemoveSingleCheese(string cheeseName)
{
    // ... remove the cheese
    return Redirect("/cheese");
}
```

*In the view:*

```html
<a asp-controller="Cheese"
   asp-action="RemoveSingleCheese"
   asp-route-cheeseName="@cheeseName">delete</a>
```

**Inputs can be submitted as an array of values to an action method.**

*In the controller:*

```cs
[Route("/cheese/remove")]
[HttpPost]
public IActionResult RemoveManyCheeses(string[] selectedCheeses)
{
    // ... remove the cheeses
    return Redirect("/cheese");
}
```

*In the view:*

```html
<form method="post">
<ul>
    @foreach (KeyValuePair<string, string> cheese in ViewBag.cheeses)
    {
        <li>
            <input name="selectedCheeses[]" type="checkbox" value="@cheese.Key" />
            <label>@cheese.Key</label>
        </li>
    }
</ul>
<input type="submit" valu="Delete Cheeses"/>
</form>
```
