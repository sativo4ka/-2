using System;
using System.Collections.Generic;
using System.Text;

namespace КТ2
{
    public class Playlist
    {
        private readonly List<string> _tracks = new();

        public void Add(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentException("Title cannot be empty.", nameof(title));

            _tracks.Add(title);
        }

        public string this[int position]
        {
            get
            {
                ValidatePosition(position);
                return _tracks[position];
            }
            set
            {
                ValidatePosition(position);
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Title cannot be empty.", nameof(value));

                _tracks[position] = value;
            }
        }

        public int this[string title]
        {
            get
            {
                if (title == null)
                    return -1;

                return _tracks.IndexOf(title);
            }
        }

        private void ValidatePosition(int position)
        {
            if (position < 0 || position >= _tracks.Count)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(position),
                    $"Index {position} is out of range."
                );
            }
        }

        public override string ToString()
        {
            if (_tracks.Count == 0)
                return string.Empty;

            var sb = new StringBuilder();
            for (int i = 0; i < _tracks.Count; i++)
            {
                sb.Append($"{i}: {_tracks[i]}");
                if (i < _tracks.Count - 1)
                    sb.Append(", ");
            }

            return sb.ToString();
        }
    }
}
