using System;
using System.Collections.Generic;
using System.Text;

namespace AutoBogus.Template
{
  /// <summary>
  /// Used to configure the Templator.
  /// </summary>
  public class TemplateBinder : AutoBinder
  {
    internal List<Func<Type, string, (bool handled, object result)>> TypeConverters { get; } =
      new List<Func<Type, string, (bool handled, object result)>>();

    internal bool TreatMissingAsNull { get; set; } = true;

    /// <summary>
    /// Will set missing values as empty string rather than null
    /// </summary>
    public TemplateBinder TreatMissingAsEmpty()
    {
      TreatMissingAsNull = false;
      return this;
    }

    /// <summary>
    /// Add a type converter
    /// </summary>
    /// <param name="typeConverter"></param>
    /// <returns></returns>
    public TemplateBinder SetTypeConverter(Func<Type, string, (bool handled, object result)> typeConverter)
    {
      TypeConverters.Add(typeConverter);
      return this;
    }

  }
}
