using System;
using System.Collections.Generic;
using MusicShopManager.Interfaces;
using System.Text;
using System.Linq;

namespace MusicShopManager.Models
{
    public class MusicShop : IMusicShop
    {
        private List<IArticle> articles;
        private string name;
        
        public MusicShop(string name)
        {
            this.Name = name;
            this.articles = new List<IArticle>();
        }

        public IList<IArticle> Articles
        {
            get
            {
               return this.articles;
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if(string.IsNullOrWhiteSpace(value))
                { throw new ArgumentException("The name is required."); }
                this.name = value;
            }
        }

        public void AddArticle(IArticle article)
        {
            this.articles.Add(article);
        }

        public string ListArticles()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"===== {this.Name} =====");
            if (this.articles.Count != 0)
            {
                AppendArticles(this.articles, sb);
            }
            else { sb.AppendLine("The shop is empty. Come back soon."); }

            return sb.ToString();
        }

        private void AppendArticles(List<IArticle> articles, StringBuilder sb)
        {
            var microphones = articles.Where(a => a.GetType().Name.Equals("Microphone")).OrderBy(e => e.Make).ThenBy(e => e.Model);
            if(microphones.Count() > 0)
            {
                sb.AppendLine("----- Microphones -----");
                Append(microphones, sb);
            }

            var drums = articles.Where(a => a.GetType().Name.Equals("Drum")).OrderBy(e => e.Make).ThenBy(e => e.Model);

            if (drums.Count() > 0)
            {
                sb.AppendLine("----- Drums -----");
                Append(drums, sb);
            }

            var electricGuitars = articles.Where(a => a.GetType().Name.Equals("ElectricGuitar")).OrderBy(e => e.Make).ThenBy(e => e.Model);
            if (electricGuitars.Count() > 0)
            {
                sb.AppendLine("----- Electric guitars -----");
                Append(electricGuitars, sb);
            }

            var acousticGuitars = articles.Where(a => a.GetType().Name.Equals("AcousticGuitar")).OrderBy(e => e.Make).ThenBy(e => e.Model);
            if (acousticGuitars.Count() > 0)
            {
                sb.AppendLine("----- Acoustic guitars -----");
                Append(acousticGuitars, sb);
            }

            var bassGuitars = articles.Where(a => a.GetType().Name.Equals("BassGuitar")).OrderBy(e => e.Make).ThenBy(e => e.Model);
            if (bassGuitars.Count() > 0)
            {
                sb.AppendLine("----- Bass guitars -----");
                Append(bassGuitars, sb);
            }
        }

        private void Append(IOrderedEnumerable<IArticle> articles, StringBuilder sb)
        {
            foreach (var article in articles)
            {
                sb.AppendLine(article.ToString());
            }
        }

        public void RemoveArticle(IArticle article)
        {
            this.articles.Remove(article);
        }
    }
}
