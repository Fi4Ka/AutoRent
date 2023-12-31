﻿using AutoRentWebDomain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AutoRentWebDomain.EnumExtension
{
    public static class EnumExtensions
    {
        public static string GetDisplayName(this System.Enum enumValue)
        {
            return enumValue.GetType()
                .GetMember(enumValue.ToString())
                .First()
                .GetCustomAttribute<DisplayAttribute>()
                ?.GetName() ?? "Неопределенный";
        }
        public static int GetByDisplayName(this System.Enum enumValue,string displayName)
        {
            switch (displayName)
            {
                case "Пользователь":
                    return (int) Role.User;
                case "Представитель компании":
                    return (int)Role.Delegate;
                case "Админ":
                    return (int)Role.Admin;
                    default : return -1;
            }
        }
    }
}
