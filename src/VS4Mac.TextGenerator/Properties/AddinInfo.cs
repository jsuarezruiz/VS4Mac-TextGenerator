using System;
using System.Runtime.InteropServices;
using Mono.Addins;
using Mono.Addins.Description;

[assembly: Addin(
    "TextGenerator",
    Namespace = "MonoDevelop",
    Version = "0.1", 
    Category = "IDE extensions"
)]

[assembly: AddinName("Text Generator")]
[assembly: AddinCategory("IDE extensions")]
[assembly: AddinDescription("A VS4Mac addin for generating dummy text.")]
[assembly: AddinAuthor("Javier Suárez Ruiz")]
[assembly: AddinUrl("https://github.com/jsuarezruiz/VS4Mac-TextGenerator")]

[assembly: CLSCompliant(false)]
[assembly: ComVisible(false)]