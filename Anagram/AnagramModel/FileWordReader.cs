using System;
using System.IO;

namespace AnagramModel {
    public class FileWordReader : IWordReader, IDisposable {
        private StreamReader streamReader;

        public FileWordReader(String fullName) {
            if(File.Exists(fullName)) {
                streamReader = new StreamReader(fullName);
            } else {
                throw new FileNotFoundException(
                          String.Format("File {0} does not exist.", fullName)
                      );
            }
        }

        public String NextWord() {
            return streamReader.ReadLine();
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing) {
            if (!disposedValue) {
                if (disposing) {
                    streamReader.Dispose();
                }
                disposedValue = true;
            }
        }

        public void Dispose() {
            Dispose(true);
        }
        #endregion
    }
}
