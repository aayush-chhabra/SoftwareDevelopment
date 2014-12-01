﻿using System;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
//using EnumBlog.Resources;

namespace Capstone.Extensions
{
    public static class HtmlHelperExtensions
    {
        public static IHtmlString EnumDropDownListFor<TModel, TEnum>(this HtmlHelper<TModel> html, Expression<Func<TModel, TEnum>> expression)
        {
            var metadata = ModelMetadata.FromLambdaExpression(expression, html.ViewData);

            var enumType = Nullable.GetUnderlyingType(metadata.ModelType) ?? metadata.ModelType;

            var enumValues = Enum.GetValues(enumType).Cast<object>();

            var items = from enumValue in enumValues
                        select new SelectListItem
                        {
                            //Text = GetResourceValueForEnumValue(enumValue),
                            Text = enumValue.ToString(),
                            Value = enumValue.ToString(),
                            //Value = ((int)enumValue).ToString(),
                            Selected = enumValue.Equals(metadata.Model)
                        };


            return html.DropDownListFor(expression, items, string.Empty, null);
        }
    }
}