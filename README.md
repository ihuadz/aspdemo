# Web 开发示例

Http 常用请求方式：post get put delete

请求+响应   调用+返回结果

- 前端发起请求
- 后端接到请求
  - 过滤前端请求数据
  - 查询数据库
  - 处理数据
  - 返回结果
- 前接收结果
- 前端渲染

## 前端

### 开发语言

HTML + CSS + JS

教程：[MDN Web Docs](https://developer.mozilla.org/zh-CN/)

### 扩展插件

前端组件库：bootstrap

插件：jquery

可视化插件：[Apache ECharts](https://echarts.apache.org/zh/index.html)、**[PlotlyJS](https://plotly.com/javascript/)**、[CanvasXpress](https://www.canvasxpress.org/)

## 后端

### 开发语言

- C# 
  - 教程：[C# 指南 - .NET 托管语言 | Microsoft Learn](https://learn.microsoft.com/zh-cn/dotnet/csharp/)
- SQL
  - [SQL 教程 | 菜鸟教程](https://www.runoob.com/sql/sql-tutorial.html)

### 框架

- Asp.net core mvc
  - [ASP.NET Core MVC 概述 | Microsoft Learn](https://learn.microsoft.com/zh-cn/aspnet/core/mvc/overview?view=aspnetcore-9.0)

### 数据库

ORM 框架

- Dapper
- EF Core

CRUD 增删改查

- Sqlserver
- Mysql
- **SQLite3**

## 部署

示例使用 Linux + nginx + systemd 部署项目，使用Windows+IIS部署可参考

Windows

- [将 ASP.NET Core 应用发布到 IIS | Microsoft Learn](https://learn.microsoft.com/zh-cn/aspnet/core/tutorials/publish-to-iis?view=aspnetcore-9.0&tabs=visual-studio)

Linux

- [使用 Nginx 在 Linux 上托管 ASP.NET Core | Microsoft Learn](https://learn.microsoft.com/zh-cn/aspnet/core/host-and-deploy/linux-nginx?view=aspnetcore-9.0&tabs=linux-ubuntu)
- [在Linux上使用Nginx部署ASP.NET Core应用 · 珩宇Coding](https://ihuadz.top/posts/dotnet/004-在linux上部署asp.net-core应用/)

本示例目录

- 应用目录：/var/www/AspDemo

- 后台进程配置文件：/etc/systemd/system/kestrel-aspdemo.service

- nginx配置文件：/etc/nginx/conf.d/aspdemo.conf

## 工具

- VS Code
- Navicat
- HexHub 服务器工具
- nginx



## 示例地址

https://aspdemo.ihuadz.top/