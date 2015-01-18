This is a helper library that allows you to get properties/fields/methods using lambda expressions.
Example:

    var property = Info.PropertyOf<You>(u => u.Property);

I'm pretty sure I've seen other libraries for that before, but now I can't find them.  
[LambdaReflection](https://github.com/Suremaker/LambdaReflection) looks cool, but brings in the whole DelegateDecompiler, which feels like an overkill.
