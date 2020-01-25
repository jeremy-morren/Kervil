# CsvSerializer
This project is a simple library for serializing and deserialization CSV test.

If you do install the above package or clone the repo, please do not hesitate to contact me at jeremy.morren@outlook.com.  I would love to know why you are using it and what features should be added in future.

For now, only primitive properties are supported.  Getting started is as simple as:

	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;
	using System.IO;
	using CsvDocument;

	namespace CsvTest
	{
		class Program
		{
			public static void Main(string[] args)
			{
				//Sample CSV
				string csv = "Boolean Column,Integer Column,Text Column\r\ntrue,5,Row 1\r\nfalse,1,Row 2\r\n";
				CsvSerializer<CsvItem> serializer = new CsvSerializer<CsvItem>(); //New Serializer
				StringReader reader = new StringReader(csv); //Create a Stream with Csv Text
				IEnumerable<CsvItem> csvItems = serializer.DeSerialize(reader); //Deserialize Csv Text
				StringWriter writer = new StringWriter(); //Create a new Stream to write Csv Text to
				serializer.Serialize(writer, csvItems); //Serialize Items back to Csv
			}
		}

		class CsvItem
		{
			[CsvColumn("Boolean Column", 0)]
			public bool Boolean { get; set; }

			[CsvColumn("Integer Column", 1)]
			public int Integer { get; set; }
			
			[CsvColumn("Text Column", 2)]
			public string Text { get; set; }
			
			[CsvIgnore]
			public decimal Ignore { get; set; }
		}
	}




