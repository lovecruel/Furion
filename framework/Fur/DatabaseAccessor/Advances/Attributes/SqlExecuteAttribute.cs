﻿// -----------------------------------------------------------------------------
// Fur 是 .NET 5 平台下极易入门、极速开发的 Web 应用框架。
// Copyright © 2020 Fur, Baiqian Co.,Ltd.
//
// 框架名称：Fur
// 框架作者：百小僧
// 框架版本：1.0.0
// 官方网站：http://chinadot.net
// 源码地址：Gitee：https://gitee.com/monksoul/Fur 
// 				   Github：https://github.com/monksoul/Fur 
// 开源协议：Apache-2.0（http://www.apache.org/licenses/LICENSE-2.0）
// -----------------------------------------------------------------------------

using Fur.DependencyInjection;
using System;

namespace Fur.DatabaseAccessor
{
    /// <summary>
    /// Sql 执行特性
    /// </summary>
    [SkipScan, AttributeUsage(AttributeTargets.Method)]
    public class SqlExecuteAttribute : SqlSentenceProxyAttribute
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="sql">sql 语句</param>
        public SqlExecuteAttribute(string sql) : base(sql)
        {
        }
    }
}