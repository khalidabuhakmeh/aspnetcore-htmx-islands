using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.OutputCaching;

[OutputCache(Duration = 100),
 ResponseCache(
     Duration = 100,
     Location = ResponseCacheLocation.Any,
     NoStore = false)]
public class IndexModel(ILogger<IndexModel> logger) 
    : PageModel;