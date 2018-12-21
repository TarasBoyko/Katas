using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject
{
    // A container for text output.
    // The class only accumulate text output and privides access to it.
    // The charasters of the text output are in unicode encoding.
    class TextOutputStorageDevice : TextWriter
    {
        // Initializes "TextOutputStorageDevice" object.
        public TextOutputStorageDevice()
        {
            Storage = "";
        }
        public string Storage { get; protected set; } // text output storage

        // Appends @data to the storage.
        // @data specifies data for storing.
        public override void Write(string data)
        {
            Storage += data;
        }

        // Appends @data and ending new line character to the storage.
        // @data specifies data for storing.
        public override void WriteLine(string data)
        {
            Storage += data + Environment.NewLine;
        }

        // A property, that always returns unicode encoding.
        public override Encoding Encoding
        {
            get
            {
                return Encoding.Unicode;
            }
        }
    } // TextOutputStorageDevice
} // UnitTestProject
