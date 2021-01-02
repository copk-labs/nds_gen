using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using static  NDS_GEN.Program;

namespace NDS_GEN
{
    public class Index
    {
        private string _indexLocation; private string IndexLocation {
            get => _indexLocation;
            set => _indexLocation = File.Exists(value) ? value : throw new ArgumentException("Invalid Path for index");
        }

        private Dictionary<string, string> _fileTable; private Dictionary<string, string> FileTable {
            get => _fileTable;
            set => _fileTable = CheckTable(value) ? value : throw new ArgumentException("File table corrupted or invalid.");
        }

        private static bool CheckTable(Dictionary<string, string> table)
        {
            foreach (var line in table)
            {
                CheckHash(line.Value, line.Key);
            }
            return true;
        }

        public Index(string indexLocation="00.index")
        {
            IndexLocation = indexLocation;
            var bufferTable = new Dictionary<string, string>();
            var indexContent = File.ReadAllText(IndexLocation).DecodeBase64();
            var regex = new Regex(@"(^(?<hash>[A-Fa-f0-9]{64}) \| (?<filePath>.{1,4}\.nds))*");
            var matches = regex.Matches(indexContent);
            for (var index = 0; index < matches.Count; index++)
            {
                var match = matches[index];
                var groups = match.Groups;
                bufferTable.Add(groups["hash"].Value, groups["filePath"].Value);
            }

            CheckTable(bufferTable);
            FileTable = CheckTable(FileTable) ? bufferTable : throw new Exception("Error FileTable Invalid");
        }
    }
}