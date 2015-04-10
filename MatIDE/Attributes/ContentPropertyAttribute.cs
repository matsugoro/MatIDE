﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace MatIDE.Attributes
{
	//=========================================================================
	/// <summary>
	/// 
	/// </summary>
	//=========================================================================
	[AttributeUsage(AttributeTargets.Property, Inherited=true)]
	public class ContentPropertyAttribute : Attribute
	{
		public BindingMode BindingMode	{ get; set; }

		public ContentPropertyAttribute()
		{
		}
	}
}
