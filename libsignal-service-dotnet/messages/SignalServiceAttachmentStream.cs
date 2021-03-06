using Strilanc.Value;

/**
* Copyright (C) 2017 smndtrl, golf1052
*
* This program is free software: you can redistribute it and/or modify
* it under the terms of the GNU General Public License as published by
* the Free Software Foundation, either version 3 of the License, or
* (at your option) any later version.
*
* This program is distributed in the hope that it will be useful,
* but WITHOUT ANY WARRANTY; without even the implied warranty of
* MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
* GNU General Public License for more details.
*
* You should have received a copy of the GNU General Public License
* along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/

using System;
using System.IO;

namespace libsignalservice.messages
{
    /// <summary>
    /// Represents a local SignalServiceAttachment to be sent.
    /// </summary>
    public class SignalServiceAttachmentStream : SignalServiceAttachment
    {
        private readonly Stream inputStream;
        private readonly long length;
        public readonly string FileName;
        private readonly ProgressListener listener;
        private readonly May<byte[]> preview;
        public bool VoiceNote { get; }
        

        public SignalServiceAttachmentStream(Stream inputStream, string contentType, long length, string fileName, bool voiceNote, ProgressListener listener)
           : this(inputStream, contentType, length, fileName, voiceNote, May<byte[]>.NoValue, listener)
        {
        }

        public SignalServiceAttachmentStream(Stream inputStream, String contentType, long length, string fileName, bool voiceNote, May<byte[]> preview, ProgressListener listener)
            : base(contentType)
        {
            this.inputStream = inputStream;
            this.length = length;
            FileName = fileName;
            this.listener = listener;
            VoiceNote = voiceNote;
            this.preview = preview;
        }

        public override bool isStream()
        {
            return true;
        }

        public override bool isPointer()
        {
            return false;
        }

        public Stream getInputStream()
        {
            return inputStream;
        }

        public long getLength()
        {
            return length;
        }

        public ProgressListener getListener()
        {
            return listener;
        }

        public May<byte[]> getPreview()
        {
            return preview;
        }
    }
}
