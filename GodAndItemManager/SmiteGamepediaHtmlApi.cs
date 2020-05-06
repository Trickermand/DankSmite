using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Text;

namespace GodAndItemManager
{
    internal static class SmiteGamepediaHtmlApi
    {
        internal static HtmlNode GetInnerHtmlNodeByHtmlType(HtmlNode node, string typeName)
        {
            HtmlNode innerNode = null;
            foreach (var childNodes in node.ChildNodes)
            {
                if (childNodes.Name == typeName)
                {
                    innerNode = childNodes;
                    break;
                }
            }
            return innerNode;
        }

        internal static HtmlNode GetInnerHtmlNodeById(HtmlNode node, string idName)
        {
            try
            {
                HtmlNode innerNode = null;
                foreach (var childNodes in node.ChildNodes)
                {
                    if (childNodes.Id == idName)
                    {
                        innerNode = childNodes;
                        break;
                    }
                }
                return innerNode;
            }
            catch (Exception ex)
            {
                throw new Exception($"Could not get inner HTML node by {nameof(idName)} '{idName}'.", ex);
            }
        }

        internal static HtmlNode GetInnerHtmlNodeByClass(HtmlNode node, string className)
        {
            HtmlNode innerNode = null;
            foreach (var childNodes in node.ChildNodes)
            {
                foreach (var childNodeAttributes in childNodes.Attributes)
                {
                    if (childNodeAttributes.Name == "class" && childNodeAttributes.Value == className)
                    {
                        innerNode = childNodes;
                        break;
                    }
                }
            }
            return innerNode;
        }
    }
}
