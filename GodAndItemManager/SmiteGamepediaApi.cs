using HtmlAgilityPack;
using System;
using System.Net;
using System.Collections.Generic;
using System.Text;

namespace GodAndItemManager
{
    public static class SmiteGamepediaApi
    {
        const string html_globalWrapper_Id = "global-wrapper";
        const string html_pageWrapper_Id = "pageWrapper";
        const string html_content_Id = "content";
        const string html_bodyContent_Id = "bodyContent";
        const string html_mwContentText_Id = "mw-content-text";
        const string html_mwParserOutput_Class = "mw-parser-output";
        const string html_blueWindowSortable_Class = "blue-window sortable";
        const string html_tBody_TypeName = "tbody";
        const string dateFormat = "yyyy-MM-dd";
        const string uri = "https://smite.gamepedia.com/List_of_gods";

        public static List<God> GetAllGods()
        {
            List<God> gods = new List<God>();
            
            //TODO Get full HTML from SmiteGamepediaHtmlApi
            //Then treat the full HTML in a private local method
            //See example code below
            //string fullHtml = SmiteGamepediaHtmlApi.getFullHtml();
            //List<gods> gods = GetGodNodes(fullHtml);

            //A singular godNode is a row of information in HTML format
            List<HtmlNode> godNodes = GetGodNodes();



            foreach (var godNode in godNodes)
            {
                God god = new God()
                {
                    Picture = GetGodPicture(godNode),
                    Name = GetGodName(godNode),
                    Pantheon = GetGodPantheon(godNode),
                    Difficulty = GetGodDifficulty(godNode),
                    FavorCost = GetGodFavorCost(godNode),
                    GemsCost = GetGodGemsCost(godNode),
                    ReleaseDate = GetGodReleaseDate(godNode)
                };
                god.SetAttackType(GetGodAttackType(godNode));
                god.SetPowerType(GetGodPowerType(godNode));
                god.SetGodClass(GetGodClass(godNode));

                gods.Add(god);
            }

            return gods;
        }

        private static List<HtmlNode> GetGodNodes()
        {
            //Magic needed to do SSH/TLS calls
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            WebClient client = new WebClient();
            string fullContent = client.DownloadString(uri);

            HtmlDocument document = new HtmlDocument();
            document.LoadHtml(fullContent);

            HtmlNode tableNode = GetInnerTableBody(document);
            List<HtmlNode> godNodes = GetReleasedGods(tableNode);
            return godNodes;
        }


        //:'(

        private static string GetGodPicture(HtmlNode godNode)
        {
            
            string thumbnailSrc = godNode.ChildNodes[1].ChildNodes[0].ChildNodes[0].Attributes[1].Value;
            string src = thumbnailSrc.Remove(thumbnailSrc.IndexOf(".png") + 4).Replace("/thumb", "");
            return src;
        }

        private static string GetGodName(HtmlNode godNode)
        {
            return godNode.ChildNodes[3].InnerText.Trim();
        }

        private static string GetGodPantheon(HtmlNode godNode)
        {
            return godNode.ChildNodes[5].InnerText.Trim();
        }

        private static string GetGodAttackType(HtmlNode godNode)
        {
            return godNode.ChildNodes[7].InnerText.Trim();
        }

        private static string GetGodPowerType(HtmlNode godNode)
        {
            return godNode.ChildNodes[9].InnerText.Trim();
        }

        private static string GetGodClass(HtmlNode godNode)
        {
            return godNode.ChildNodes[11].InnerText.Trim();
        }

        private static string GetGodDifficulty(HtmlNode godNode)
        {
            return godNode.ChildNodes[13].InnerText.Trim();
        }

        private static string GetGodFavorCost(HtmlNode godNode)
        {
            return godNode.ChildNodes[15].InnerText.Trim();
        }

        private static string GetGodGemsCost(HtmlNode godNode)
        {
            return godNode.ChildNodes[17].InnerText.Trim();
        }

        private static string GetGodReleaseDate(HtmlNode godNode)
        {
            return godNode.ChildNodes[19].InnerText.Trim();
        }

        private static List<HtmlNode> GetReleasedGods(HtmlNode tableNode)
        {
            List<HtmlNode> godNodes = new List<HtmlNode>();
            bool isFirstNode = true;

            foreach (HtmlNode node in tableNode.ChildNodes)
            {
                if (isFirstNode && node.Name == "tr")
                {
                    isFirstNode = false;
                    continue;
                }

                if (node.Name == "tr" && GodIsReleased(node))
                {
                    godNodes.Add(node);
                }
            }

            return godNodes;
        }

        private static bool GodIsReleased(HtmlNode node)
        {
            try
            {
                if (DateTime.ParseExact(node.LastChild.InnerText.Replace("\n", ""), dateFormat, null) <= DateTime.Now)
                    return true;
            }
            catch (Exception)
            {
                //throw;
            }

            return false;
        }

        private static HtmlNode GetInnerTableBody(HtmlDocument document)
        {
            try
            {
                //TODO: This line has a class tag in HTML, refactor so it uses the method GetInnerHtmlNodeBy... 
                HtmlNode body = document.DocumentNode.ChildNodes[2].ChildNodes[3];

                HtmlNode globalWrapper = SmiteGamepediaHtmlApi.GetInnerHtmlNodeById(body, html_globalWrapper_Id);
                HtmlNode pageWrapper = SmiteGamepediaHtmlApi.GetInnerHtmlNodeById(globalWrapper, html_pageWrapper_Id);
                HtmlNode content = SmiteGamepediaHtmlApi.GetInnerHtmlNodeById(pageWrapper, html_content_Id);
                HtmlNode bodyContent = SmiteGamepediaHtmlApi.GetInnerHtmlNodeById(content, html_bodyContent_Id);
                HtmlNode mwContentText = SmiteGamepediaHtmlApi.GetInnerHtmlNodeById(bodyContent, html_mwContentText_Id);
                HtmlNode mwParserOutput = SmiteGamepediaHtmlApi.GetInnerHtmlNodeByClass(mwContentText, html_mwParserOutput_Class);
                HtmlNode blueWindowSortable = SmiteGamepediaHtmlApi.GetInnerHtmlNodeByClass(mwParserOutput, html_blueWindowSortable_Class);
                return SmiteGamepediaHtmlApi.GetInnerHtmlNodeByHtmlType(blueWindowSortable, html_tBody_TypeName);
            }
            catch (Exception)
            {
                throw;
            }
        }

        

    }
}
