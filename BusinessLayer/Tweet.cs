
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace BusinessLayer
{
    public class Tweet : MessageSupplement
    {
        public Tweet() { }

        //attributes are public for serialization purposes
        public List<String> hashtags;
        public List<String> mentions;

        public Tweet(String sender, String text)
        {
            this.sender = sender;
            this.text = text;
            this.decorate(2);
        }

        public List<String> getHashtags()
        {
            return hashtags;
        }

        public List<String> getMentions()
        {
            return mentions;
        }

        public void findHashtags(Dictionary<String, int> trending)
        {
            String[] tokenized = this.text.Split(' ');

            for (int i = 0; i < tokenized.Length; i++)
            {
                if (tokenized[i].Contains('#'))
                {
                    int s = 0, e = 1;
                    while (tokenized[i][s] != '#' && s < tokenized[i].Length)
                        s++;
                    while (Regex.IsMatch(tokenized[i][s + e].ToString(), @"[a-z0-9]", RegexOptions.IgnoreCase) && e < tokenized[i].Length - 1)
                        e++;

                    String hashtag = tokenized[i].Substring(s, e + 1).ToLower();
                    if (Regex.IsMatch(hashtag, @"#([a-z0-9]+)", RegexOptions.IgnoreCase))
                    {
                        if (hashtags == null)
                            hashtags = new List<String>();
                        hashtags.Add(hashtag);
                        if (!trending.ContainsKey(hashtag))
                            trending.Add(hashtag, 0);
                        trending[hashtag]++;
                    }
                }
            }
        }

        public void findMentions()
        {
            String[] tokenized = this.text.Split(' ');

            for (int i = 0; i < tokenized.Length; i++)
            {
                if (tokenized[i].Contains('@'))
                {
                    int s = 0, e = 1;
                    while (tokenized[i][s] != '@' && s < tokenized[i].Length)
                        s++;
                    while (Regex.IsMatch(tokenized[i][s + e].ToString(), @"[a-z0-9]", RegexOptions.IgnoreCase) && e < tokenized[i].Length - 1)
                        e++;

                    String mention = tokenized[i].Substring(s, e + 1).ToLower();
                    if (Regex.IsMatch(mention, @"@([a-z0-9]+)", RegexOptions.IgnoreCase))
                    {
                        if (mentions == null)
                            mentions = new List<String>();
                        mentions.Add(mention);
                    }
                }
            }
        }
    }
}