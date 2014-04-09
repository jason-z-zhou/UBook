using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using SalesManagementSystem.Models;

namespace SalesManagementSystem.DAL
{
    public class EntityContextInitializer : DropCreateDatabaseIfModelChanges<EntityContext>
    {
        protected override void Seed(EntityContext context)
        {
            //初始化用户数据
            var users = new List<User>
            {
                new User {UserID = 1, UserName = "admin001", Password = "123456", LastName = "胡", FirstName = "坤", Email = "hk_ad@ohehe.net", Tel = "13766187297"},
                new User {UserID = 2, UserName = "admin002", Password = "123456", LastName = "唐", FirstName = "兼善", Email = "tjs_ad@ohehe.net", Tel = "13135595380"},
                new User {UserID = 3, UserName = "admin003", Password = "123456", LastName = "高", FirstName = "博", Email = "gb_ad@ohehe.net", Tel = "15676346064"},
                new User {UserID = 4, UserName = "admin004", Password = "123456", LastName = "吕", FirstName = "梁伟", Email = "llw_lsm@ohehe.net", Tel = "13435418102"},
                new User {UserID = 5, UserName = "admin005", Password = "123456", LastName = "马", FirstName = "伊利", Email = "myl_wz@ohehe.net", Tel = "15814464203"},
                new User {UserID = 6, UserName = "admin006", Password = "123456", LastName = "文", FirstName = "学", Email = "wx_myl@ohehe.net", Tel = "13228704843"},
                new User {UserID = 7, UserName = "admin007", Password = "123456", LastName = "朱", FirstName = "永明", Email = "zym_ad@ohehe.net", Tel = "13282142507"},
                new User {UserID = 8, UserName = "admin008", Password = "123456", LastName = "雷", FirstName = "大川", Email = "ldc_lxb@ohehe.net", Tel = "15824379108"},
                new User {UserID = 9, UserName = "admin009", Password = "123456", LastName = "王", FirstName = "志愿", Email = "wzy_ad@ohehe.net", Tel = "15990302856"},
                new User {UserID = 10, UserName = "admin010", Password = "123456", LastName = "许", FirstName = "先平", Email = "xxp_ad@ohehe.net", Tel = "18258324659"},
                new User {UserID = 11, UserName = "ohehe001", Password = "123456", LastName = "王", FirstName = "璐璐", Email = "wll@ohehe.net", Tel = "15645688180"},
                new User {UserID = 12, UserName = "ohehe002", Password = "123456", LastName = "李", FirstName = "艳川", Email = "lyc@ohehe.net", Tel = "13435448979"},
                new User {UserID = 13, UserName = "ohehe003", Password = "123456", LastName = "胡", FirstName = "夏磊", Email = "hxl@ohehe.net", Tel = "18212960962"},
                new User {UserID = 14, UserName = "ohehe004", Password = "123456", LastName = "张", FirstName = "凯旋", Email = "zkx@ohehe.net", Tel = "13597057565"},
                new User {UserID = 15, UserName = "ohehe005", Password = "123456", LastName = "陈", FirstName = "世博", Email = "csb@ohehe.net", Tel = "15268814735"},
                new User {UserID = 16, UserName = "ohehe006", Password = "123456", LastName = "马", FirstName = "解放", Email = "mjf@ohehe.net", Tel = "18801872911"},
                new User {UserID = 17, UserName = "ohehe007", Password = "123456", LastName = "晓", FirstName = "微微", Email = "xww@ohehe.net", Tel = "13145510442"},
                new User {UserID = 18, UserName = "ohehe008", Password = "123456", LastName = "王", FirstName = "菲菲", Email = "wff@ohehe.net", Tel = "15655125090"},
                new User {UserID = 19, UserName = "ohehe009", Password = "123456", LastName = "朱", FirstName = "七七", Email = "zqq@ohehe.net", Tel = "18658727306"},
                new User {UserID = 20, UserName = "ohehe010", Password = "123456", LastName = "隆", FirstName = "八百", Email = "l800@ohehe.net", Tel = "15197036130"},
                new User {UserID = 21, UserName = "ohehe011", Password = "123456", LastName = "罗", FirstName = "德彪", Email = "ldb@ohehe.net", Tel = "13715221143"},
                new User {UserID = 22, UserName = "ohehe012", Password = "123456", LastName = "吴", FirstName = "建立", Email = "wjl_912@ohehe.net", Tel = "13711361185"},
                new User {UserID = 23, UserName = "ohehe013", Password = "123456", LastName = "闫", FirstName = "郭跃", Email = "ygy@ohehe.net", Tel = "13408355841"},
                new User {UserID = 24, UserName = "ohehe014", Password = "123456", LastName = "周", FirstName = "资源", Email = "zzy_009@ohehe.net", Tel = "13852439449"},
                new User {UserID = 25, UserName = "ohehe015", Password = "123456", LastName = "李", FirstName = "世杰", Email = "lsj_16@ohehe.net", Tel = "15027827135"},
                new User {UserID = 26, UserName = "ohehe016", Password = "123456", LastName = "张", FirstName = "太平", Email = "ztp@ohehe.net", Tel = "13557876970"},
                new User {UserID = 27, UserName = "ohehe017", Password = "123456", LastName = "唐", FirstName = "嘉业", Email = "tjy@ohehe.net", Tel = "18205212895"},
                new User {UserID = 28, UserName = "ohehe018", Password = "123456", LastName = "吴", FirstName = "利亚", Email = "wly_012@ohehe.net", Tel = "13815217660"},
                new User {UserID = 29, UserName = "ohehe019", Password = "123456", LastName = "艾", FirstName = "国庆", Email = "agq@ohehe.net", Tel = "13712901145"},
                new User {UserID = 30, UserName = "ohehe020", Password = "123456", LastName = "王", FirstName = "中合", Email = "wzh@ohehe.net", Tel = "15277016110"},
                new User {UserID = 31, UserName = "ohehe021", Password = "123456", LastName = "钱", FirstName = "四强", Email = "qsq@ohehe.net", Tel = "18212902478"},
                new User {UserID = 32, UserName = "ohehe022", Password = "123456", LastName = "刘", FirstName = "豪杰", Email = "lhj_712@ohehe.net", Tel = "13424792401"},
                new User {UserID = 33, UserName = "ohehe023", Password = "123456", LastName = "刘", FirstName = "问天", Email = "lwt_008@ohehe.net", Tel = "13474166664"},
                new User {UserID = 34, UserName = "ohehe024", Password = "123456", LastName = "马", FirstName = "思琪", Email = "msq_123@ohehe.net", Tel = "18251370489"},
                new User {UserID = 35, UserName = "ohehe025", Password = "123456", LastName = "王", FirstName = "利芬", Email = "wfl_ll@ohehe.net", Tel = "15022555479"},
                new User {UserID = 36, UserName = "ohehe026", Password = "123456", LastName = "张", FirstName = "世君", Email = "zsj_jr@ohehe.net", Tel = "18722256294"},
                new User {UserID = 37, UserName = "ohehe027", Password = "123456", LastName = "何", FirstName = "宇桓", Email = "hyh@ohehe.net", Tel = "13080681087"},
                new User {UserID = 38, UserName = "ohehe028", Password = "123456", LastName = "陈", FirstName = "山成", Email = "csc@ohehe.net", Tel = "13750027778"},
                new User {UserID = 39, UserName = "ohehe029", Password = "123456", LastName = "冯", FirstName = "伟强", Email = "fwq@ohehe.net", Tel = "18278504199"},
                new User {UserID = 40, UserName = "ohehe030", Password = "123456", LastName = "马", FirstName = "丽娟", Email = "mlj_098@ohehe.net", Tel = "18269594111"},
            };
            users.ForEach(s => context.Users.Add(s));

            //初始化角色数据
            var roles = new List<Role>
            {
                new Role {RoleID = 1, RoleName = "系统管理员", Description = "负责监督、管理并维护整套系统，保证系统的正常运行，拥有系统内最大的权限"},
                new Role {RoleID = 2, RoleName = "员工管理员", Description = "可以对员工的账号、权限进行添加、删除、修改、查看操作，可以管理系统管理员外的一切账号"},
                new Role {RoleID = 3, RoleName = "产品管理员", Description = "可以对产品的分类、产品单品进行添加、删除、修改、查看操作，保证系统内产品信息与实际销售情况对应"},
                new Role {RoleID = 4, RoleName = "销售点管理员", Description = "可以按照真实情况对销售点进行添加、删除、修改、查看操作"},
                new Role {RoleID = 5, RoleName = "评审条目管理员", Description = "可以对评审条目进行添加、删除、修改、查看操作，以与公司需求对应"},
                new Role {RoleID = 6, RoleName = "业务评审员", Description = "可以按给定的评审条目对销售点的业务进行评审并提交给系统"},
                new Role {RoleID = 7, RoleName = "销售员", Description = "可以对销售点的信息进行查看、编辑，提交销售点的销售记录和业务信息"}
            };
            roles.ForEach(s => context.Roles.Add(s));

            context.Roles.Find(1).Users = new List<User>
            {
                context.Users.Find(1),
                context.Users.Find(2),
            };
            context.Roles.Find(2).Users = new List<User>
            {
                context.Users.Find(1),
                context.Users.Find(2),
                context.Users.Find(3),
            };
            context.Roles.Find(3).Users = new List<User>
            {
                context.Users.Find(1),
                context.Users.Find(2),
                context.Users.Find(4),
            };
            context.Roles.Find(4).Users = new List<User>
            {
                context.Users.Find(1),
                context.Users.Find(2),
                context.Users.Find(5),
            };
            context.Roles.Find(5).Users = new List<User>
            {
                context.Users.Find(1),
                context.Users.Find(2),
                context.Users.Find(6),
            };
            context.Roles.Find(6).Users = new List<User>
            {
                context.Users.Find(7),
                context.Users.Find(8),
                context.Users.Find(9),
                context.Users.Find(10),
            };
            context.Roles.Find(7).Users = new List<User>
            {
                context.Users.Find(11),
                context.Users.Find(12),
                context.Users.Find(13),
                context.Users.Find(14),
                context.Users.Find(15),
                context.Users.Find(16),
                context.Users.Find(17),
                context.Users.Find(18),
                context.Users.Find(19),
                context.Users.Find(20),
                context.Users.Find(21),
                context.Users.Find(22),
                context.Users.Find(23),
                context.Users.Find(24),
                context.Users.Find(25),
                context.Users.Find(26),
                context.Users.Find(27),
                context.Users.Find(28),
                context.Users.Find(29),
                context.Users.Find(30),
                context.Users.Find(31),
                context.Users.Find(32),
                context.Users.Find(33),
                context.Users.Find(34),
                context.Users.Find(35),
                context.Users.Find(36),
                context.Users.Find(37),
                context.Users.Find(38),
                context.Users.Find(39),
                context.Users.Find(40),
            };

            //初始化商品分类数据
            var categories = new List<Category>
            {
                new Category {CategoryID = 1, CategoryName = "纯净水", Description = "纯净水及矿物质水"},
                new Category {CategoryID = 2, CategoryName = "果汁", Description = "含果汁的饮料"},
                new Category {CategoryID = 3, CategoryName = "碳酸饮料", Description = "含气饮料"},
                new Category {CategoryID = 4, CategoryName = "茶饮料", Description = "茶饮料"},
                new Category {CategoryID = 5, CategoryName = "运动饮料", Description = "运动型功能型饮料"},
                new Category {CategoryID = 6, CategoryName = "乳饮料", Description = "奶制品或乳饮料"},
                new Category {CategoryID = 7, CategoryName = "咖啡饮料", Description = "咖啡饮料"},
            };
            categories.ForEach(s => context.Categories.Add(s));

            //初始化商品数据
            var commodities = new List<Commodity>
            {
                new Commodity {CommodityID = 1, CommodityName = "可口可乐冰露矿物质水550ml", Description = "一款无调味的低端纯净水饮料。", Price = 1.00, Category = context.Categories.Find(1)},
                new Commodity {CommodityID = 2, CommodityName = "可口可乐冰露矿物质水1.5l", Description = "一款无调味的低端纯净水饮料。", Price = 2.50, Category = context.Categories.Find(1)}, 
                new Commodity {CommodityID = 3, CommodityName = "农夫山泉饮用天然水550ml", Description = "源自天然的水饮料。", Price = 1.50, Category = context.Categories.Find(1)}, 
                new Commodity {CommodityID = 4, CommodityName = "农夫山泉饮用天然水1.5l", Description = "源自天然的水饮料。", Price = 3.00, Category = context.Categories.Find(1)},
                new Commodity {CommodityID = 5, CommodityName = "美汁源果粒橙550ml", Description = "一款富含果肉纤维和维c的橙汁饮料。", Price = 2.50, Category = context.Categories.Find(2)},
                new Commodity {CommodityID = 6, CommodityName = "美汁源果粒橙1250ml", Description = "一款富含果肉纤维和维c的橙汁饮料。", Price =5.50, Category = context.Categories.Find(2)},
                new Commodity {CommodityID = 7, CommodityName = "美汁源美丽果550ml", Description = "一款富含果肉纤维和蜂蜜的西柚汁饮料。", Price = 2.50, Category = context.Categories.Find(2)},
                new Commodity {CommodityID = 8, CommodityName = "美汁源美丽果550ml促销", Description = "一款富含果肉纤维和蜂蜜的西柚汁饮料。", Price = 2.0, Category = context.Categories.Find(2)},
                new Commodity {CommodityID = 9, CommodityName = "美汁源美丽果1250ml", Description = "一款富含果肉纤维和蜂蜜的西柚汁饮料。", Price =5.50, Category = context.Categories.Find(2)},
                new Commodity {CommodityID = 10, CommodityName = "美汁源清凉橙550ml", Description = "一款富含果肉纤维和加入了天然罗汉果、金银花的橙汁饮料。", Price =2.50, Category = context.Categories.Find(2)},
                new Commodity {CommodityID = 11, CommodityName = "美汁源清凉橙550ml促销", Description = "一款富含果肉纤维和加入了天然罗汉果、金银花的橙汁饮料。", Price =2.00, Category = context.Categories.Find(2)},
                new Commodity {CommodityID = 12, CommodityName = "美汁源清凉橙1250ml", Description = "一款富含果肉纤维和加入了天然罗汉果、金银花的橙汁饮料。", Price =5.50, Category = context.Categories.Find(2)},
                new Commodity {CommodityID = 13, CommodityName = "可口可乐碳酸饮料600ml", Description = "最受欢迎的碳酸饮料。", Price = 2.50, Category = context.Categories.Find(3)},
                new Commodity {CommodityID = 14, CommodityName = "可口可乐碳酸饮料1.2l", Description = "最受欢迎的碳酸饮料。。", Price =5.50, Category = context.Categories.Find(3)},
                new Commodity {CommodityID = 15, CommodityName = "可口可乐碳酸饮料2l", Description = "最受欢迎的碳酸饮料", Price = 7.50, Category = context.Categories.Find(3)},
                new Commodity {CommodityID = 16, CommodityName = "健怡可口可乐355ml", Description = "无糖的可乐", Price =2.00, Category = context.Categories.Find(3)},
                new Commodity {CommodityID = 17, CommodityName = "可口可乐芬达水蜜桃味饮料 500ml", Description = "水蜜桃口味果味汽水。", Price =3.00, Category = context.Categories.Find(3)},
                new Commodity {CommodityID = 18, CommodityName = "可口可乐芬达苹果味饮料 500ml", Description = "苹果口味果味汽水", Price =3.00, Category = context.Categories.Find(3)},
                new Commodity {CommodityID = 19, CommodityName = "可口可乐芬达青柠味饮料 500ml", Description = "青柠口味果味汽水", Price =3.00, Category = context.Categories.Find(3)},
                new Commodity {CommodityID = 20, CommodityName = "可口可乐芬达橘子味饮料 500ml", Description = "橘子口味果味汽水", Price =3.00, Category = context.Categories.Find(3)},
                new Commodity {CommodityID = 21, CommodityName = "可口可乐雪碧冰茶味瓶装 500ml", Description = "茶口味薄荷柠檬汽水", Price =3.00, Category = context.Categories.Find(3)},
                new Commodity {CommodityID = 22, CommodityName = "可口可乐雪碧冰茶味瓶装 500ml促销", Description = "茶口味薄荷柠檬汽水", Price =2.50, Category = context.Categories.Find(3)}, 
                new Commodity {CommodityID = 23, CommodityName = "可口可乐雪碧瓶装  500ml", Description = "柠檬口味汽水", Price =2.50, Category = context.Categories.Find(3)},
                new Commodity {CommodityID = 24, CommodityName = "可口可乐雪碧瓶装  1.2L", Description = "柠檬口味汽水", Price =5.50, Category = context.Categories.Find(3)},
                new Commodity {CommodityID = 25, CommodityName = "可口可乐雪碧瓶装  2L", Description = "柠檬口味汽水", Price =7.50, Category = context.Categories.Find(3)},
                new Commodity {CommodityID = 26, CommodityName = "可口可乐碳酸饮料600ml", Description = "清新好喝的柠檬红茶饮料。", Price = 3.50, Category = context.Categories.Find(4)},
                new Commodity {CommodityID = 27, CommodityName = "广东王老吉凉茶250ml ", Description = "中草药熬制，具有清热去湿等功效的“药茶”。", Price =2.50, Category = context.Categories.Find(4)},
                new Commodity {CommodityID = 28, CommodityName = "天喔蜂蜜柚子茶饮料500ml ", Description = "全天然的蜂蜜与健康的水果柚子相结合", Price =3.50, Category = context.Categories.Find(4)},
                new Commodity {CommodityID = 29, CommodityName = "天喔蜂蜜柚子茶饮料500ml促销", Description = "全天然的蜂蜜与健康的水果柚子相结合", Price =3.00, Category = context.Categories.Find(4)},
                new Commodity {CommodityID = 30, CommodityName = "康师傅冰红茶500ml", Description = "柠檬红茶饮料", Price =2.50, Category = context.Categories.Find(4)},
                new Commodity {CommodityID = 31, CommodityName = "康师傅茉莉清茶500ml", Description = "含苞双瓣茉莉与上等茶叶制成", Price =2.50, Category = context.Categories.Find(4)},
                new Commodity {CommodityID = 32, CommodityName = "康师傅绿茶550ml ", Description = "蜂蜜绿茶饮料", Price =2.50, Category = context.Categories.Find(4)},
                new Commodity {CommodityID = 33, CommodityName = "红牛功能饮料 250ml ", Description = "维生素功能饮料", Price =5.50, Category = context.Categories.Find(5)},
                new Commodity {CommodityID = 34, CommodityName = "脉动维生素饮料 600ml  ", Description = "多种B族活性维生素及维生素C，具有天然清新的水果味", Price =4.00, Category = context.Categories.Find(5)},
                new Commodity {CommodityID = 35, CommodityName = "可口可乐冰露机能水柠檬味 500ml ", Description = "柠檬口味维生素饮料", Price =3.50, Category = context.Categories.Find(5)},
                new Commodity {CommodityID = 36, CommodityName = "娃哈哈营养快线原味500ml  ", Description = "含有维生素A、D、E、B3、B6、B12、钾、钙、钠、镁等15种营养素", Price =4.00, Category = context.Categories.Find(5)},
                new Commodity {CommodityID = 37, CommodityName = "娃哈哈营养快线原味500ml 促销 ", Description = "含有维生素A、D、E、B3、B6、B12、钾、钙、钠、镁等15种营养素", Price =3.50, Category = context.Categories.Find(5)},
                new Commodity {CommodityID = 38, CommodityName = "海南椰树牌椰汁245ml ", Description = "是一种不加香精、糖精、防腐剂不含胆固醇的天然植物蛋白饮料", Price =2.50, Category = context.Categories.Find(5)},
                new Commodity {CommodityID = 39, CommodityName = "银鹭花生牛奶 500ml ", Description = "精选优质花生,经过慢火烘焙与精心研磨,再与香浓优质脱脂乳粉完美融合", Price =4.00, Category = context.Categories.Find(5)},
                new Commodity {CommodityID = 40, CommodityName = "娃哈哈AD钙奶220ml   ", Description = "酸甜口味的乳饮料", Price =1.50, Category = context.Categories.Find(5)},
                new Commodity {CommodityID = 41, CommodityName = "伯朗蓝山风味咖啡 330ml  ", Description = "以蓝山咖啡调合而成的高品质咖啡", Price =4.00, Category = context.Categories.Find(6)},
                new Commodity {CommodityID = 42, CommodityName = "伯朗焦糖玛奇朵风味咖啡 330ml  ", Description = "香浓鲜奶与焦糖香味结合特级咖啡创造出的美味组合，让咖啡的香醇中夹着焦糖的香味。", Price =4.00, Category = context.Categories.Find(6)},
                new Commodity {CommodityID = 43, CommodityName = "雅哈咖啡拿铁 250ml ", Description = "经过重度烘焙与意式萃取的雅哈咖啡香气浓郁、质感醇厚、口感爽滑", Price =3.00, Category = context.Categories.Find(6)},
                new Commodity {CommodityID = 44, CommodityName = "雅哈咖啡奶咖精选 250ml ", Description = "经过重度烘焙与意式萃取的雅哈咖啡香气浓郁、质感醇厚、口感爽滑。", Price =3.00, Category = context.Categories.Find(6)},
                new Commodity {CommodityID = 45, CommodityName = "雅哈咖啡奶咖精选 250ml 促销", Description = "经过重度烘焙与意式萃取的雅哈咖啡香气浓郁、质感醇厚、口感爽滑。", Price =2.50, Category = context.Categories.Find(6)},
            };
            commodities.ForEach(s => context.Commodities.Add(s));

            //初始化片区数据
            var regions = new List<Region>
            {
                new Region {RegionID = 1, RegionName = "硚口片区", Address = "湖北省武汉市硚口区"},
                new Region {RegionID = 2, RegionName = "江汉片区", Address = "湖北省武汉市江汉区"},
                new Region {RegionID = 3, RegionName = "江岸片区", Address = "湖北省武汉市江岸区"},
                new Region {RegionID = 4, RegionName = "汉阳片区", Address = "湖北省武汉市汉阳区"},
                new Region {RegionID = 5, RegionName = "洪山片区", Address = "湖北省武汉市洪山区"},
                new Region {RegionID = 6, RegionName = "武昌片区", Address = "湖北省武汉市武昌区"},
                new Region {RegionID = 7, RegionName = "青山片区", Address = "湖北省武汉市青山区"},
            };
            regions.ForEach(s => context.Regions.Add(s));

            //初始化销售点数据
            var stores = new List<Store>
            {
                new Store {StoreID = 1, StoreName = "武胜路家乐福点", Address = "湖北省武汉市硚口区中山大道244号", CreationTime = Convert.ToDateTime("2007-8-1"), Latitude = 30.568771, Longitude = 114.268914, Region = context.Regions.Find(1), Employees = new List<User>{context.Users.Find(11)}},
                new Store {StoreID = 2, StoreName = "多富商城点", Address = "湖北省武汉市硚口区长堤街多富商城处", CreationTime = Convert.ToDateTime("2008-8-1"), Latitude = 30.56977, Longitude = 114.27631, Region = context.Regions.Find(1), Employees = new List<User>{context.Users.Find(12)}},
                new Store {StoreID = 3, StoreName = "亚洲点", Address = "湖北省武汉市硚口区解放大道616号亚洲大酒店", CreationTime = Convert.ToDateTime("2006-2-23"), Latitude = 30.57750, Longitude = 114.26137, Region = context.Regions.Find(1), Employees = new List<User>{context.Users.Find(13)}},
                new Store {StoreID = 4, StoreName = "葛洲坝酒店点", Address = "湖北省武汉市硚口区解放大道558号", CreationTime = Convert.ToDateTime("2008-4-23"), Latitude = 30.57641, Longitude = 114.25125, Region = context.Regions.Find(1), Employees = new List<User>{context.Users.Find(14)}},
                new Store {StoreID = 5, StoreName = "武展点", Address = "湖北省武汉市江汉区京汉大道武汉国际会展中心", CreationTime = Convert.ToDateTime("2008-2-12"), Latitude = 30.57976, Longitude = 114.27384, Region = context.Regions.Find(2), Employees = new List<User>{context.Users.Find(15)}},
                new Store {StoreID = 6, StoreName = "金盾点", Address = "湖北省武汉市江汉区青年路350号", CreationTime = Convert.ToDateTime("2007-12-11"), Latitude = 30.60041, Longitude = 114.26356, Region = context.Regions.Find(2), Employees = new List<User>{context.Users.Find(16)}},
                new Store {StoreID = 7, StoreName = "菱角湖点", Address = "湖北省武汉市江汉区新华下路169号", CreationTime = Convert.ToDateTime("2007-2-14"), Latitude = 30.61184, Longitude = 114.27120, Region = context.Regions.Find(2), Employees = new List<User>{context.Users.Find(17)}},
                new Store {StoreID = 8, StoreName = "解放公园点", Address = "湖北省武汉市江岸区惠济路15号", CreationTime = Convert.ToDateTime("2007-12-14"), Latitude = 30.60792, Longitude = 114.28912, Region = context.Regions.Find(3), Employees = new List<User>{context.Users.Find(18)}},
                new Store {StoreID = 9, StoreName = "江滩汇申点", Address = "湖北省武汉市江岸区沿江大道234号", CreationTime = Convert.ToDateTime("2008-6-17"), Latitude = 30.60242, Longitude = 114.31109, Region = context.Regions.Find(3), Employees = new List<User>{context.Users.Find(19)}},
                new Store {StoreID = 10, StoreName = "武汉图书馆点", Address = "湖北省武汉市江岸区建设大道700号", CreationTime = Convert.ToDateTime("2008-4-12"), Latitude = 30.60258, Longitude = 114.28286, Region = context.Regions.Find(3), Employees = new List<User>{context.Users.Find(20)}},
                new Store {StoreID = 11, StoreName = "武汉杂技厅点", Address = "湖北省武汉市江岸区建设大道739号", CreationTime = Convert.ToDateTime("2008-3-23"), Latitude = 30.598926, Longitude = 114.276186, Region = context.Regions.Find(3), Employees = new List<User>{context.Users.Find(21)}},
                new Store {StoreID = 12, StoreName = "欣悦点", Address = "湖北省武汉市汉阳区鹦鹉大道259号", CreationTime = Convert.ToDateTime("2006-8-8"), Latitude = 30.53373, Longitude = 114.26700, Region = context.Regions.Find(4), Employees = new List<User>{context.Users.Find(22)}},
                new Store {StoreID = 13, StoreName = "动物园点", Address = "湖北省武汉市汉阳区动物园路特1号", CreationTime = Convert.ToDateTime("2008-2-19"), Latitude = 30.54327, Longitude = 114.24356, Region = context.Regions.Find(4), Employees = new List<User>{context.Users.Find(23)}},
                new Store {StoreID = 14, StoreName = "莲花湖点", Address = "湖北省武汉市汉阳区汉阳大道", CreationTime = Convert.ToDateTime("2009-4-13"), Latitude = 30.54966, Longitude = 114.27822, Region = context.Regions.Find(4), Employees = new List<User>{context.Users.Find(24)}},
                new Store {StoreID = 15, StoreName = "玫瑰点", Address = "湖北省武汉市汉阳区二桥路18号", CreationTime = Convert.ToDateTime("2008-6-7"), Latitude = 30.56376, Longitude = 114.21039, Region = context.Regions.Find(4), Employees = new List<User>{context.Users.Find(25)}},
                new Store {StoreID = 16, StoreName = "财政局点", Address = "湖北省武汉市汉阳区汉阳大道594号", CreationTime = Convert.ToDateTime("2008-6-8"), Latitude = 30.55672, Longitude = 114.23254, Region = context.Regions.Find(4), Employees = new List<User>{context.Users.Find(26)}},
                new Store {StoreID = 17, StoreName = "琴台音乐厅点", Address = "湖北省武汉市汉阳区知音大道", CreationTime = Convert.ToDateTime("2008-9-12"), Latitude = 30.56067, Longitude = 114.26210, Region = context.Regions.Find(4), Employees = new List<User>{context.Users.Find(27)}},
                new Store {StoreID = 18, StoreName = "晴川阁点", Address = "湖北省武汉市汉阳区滨江大道洗马长街86号", CreationTime = Convert.ToDateTime("2009-5-14"), Latitude = 30.55561, Longitude = 114.28476, Region = context.Regions.Find(4), Employees = new List<User>{context.Users.Find(28)}},
                new Store {StoreID = 19, StoreName = "洪山公园点", Address = "湖北省武汉市洪山区武珞路509号", CreationTime = Convert.ToDateTime("2007-5-12"), Latitude = 30.53310, Longitude = 114.33549, Region = context.Regions.Find(5), Employees = new List<User>{context.Users.Find(29)}},
                new Store {StoreID = 20, StoreName = "群光广场点", Address = "湖北省武汉市洪山区珞喻路20号", CreationTime = Convert.ToDateTime("2008-10-18"), Latitude = 30.52592, Longitude = 114.35380, Region = context.Regions.Find(5), Employees = new List<User>{context.Users.Find(30)}},
                new Store {StoreID = 21, StoreName = "光谷广场点", Address = "武汉市洪山区珞瑜路726号", CreationTime = Convert.ToDateTime("2008-8-12"), Latitude = 30.50611, Longitude = 114.39879, Region = context.Regions.Find(5), Employees = new List<User>{context.Users.Find(31)}},
                new Store {StoreID = 22, StoreName = "武汉大学点", Address = "湖北省武汉市武昌区珞珈山路武汉大学校内", CreationTime = Convert.ToDateTime("2008-10-27"), Latitude = 30.53374, Longitude = 114.35787, Region = context.Regions.Find(6), Employees = new List<User>{context.Users.Find(32)}},
                new Store {StoreID = 23, StoreName = "武昌火车站点", Address = "湖北省武汉市武昌区中山路530号", CreationTime = Convert.ToDateTime("2009-11-23"), Latitude = 30.527202, Longitude = 114.313959, Region = context.Regions.Find(6), Employees = new List<User>{context.Users.Find(33)}},
                new Store {StoreID = 24, StoreName = "海洋世界点", Address = "湖北省武汉市武昌区沿湖大道20号", CreationTime = Convert.ToDateTime("2007-9-23"), Latitude = 30.57349, Longitude = 114.37386, Region = context.Regions.Find(6), Employees = new List<User>{context.Users.Find(34)}},
                new Store {StoreID = 25, StoreName = "徐东点", Address = "湖北省武汉市武昌区徐东大街7号", CreationTime = Convert.ToDateTime("2008-8-14"), Latitude = 30.58894, Longitude = 114.34648, Region = context.Regions.Find(6), Employees = new List<User>{context.Users.Find(35)}},
                new Store {StoreID = 26, StoreName = "湖北大学点", Address = "湖北省武汉市武昌区学院路11号", CreationTime = Convert.ToDateTime("2008-9-10"), Latitude = 30.57752, Longitude = 114.32909, Region = context.Regions.Find(6), Employees = new List<User>{context.Users.Find(36)}},
                new Store {StoreID = 27, StoreName = "凤凰大厦点", Address = "湖北省武汉市武昌区中山路312号", CreationTime = Convert.ToDateTime("2008-7-1"), Latitude = 30.55306, Longitude = 114.31579, Region = context.Regions.Find(6), Employees = new List<User>{context.Users.Find(37)}},
                new Store {StoreID = 28, StoreName = "黄鹤楼点", Address = "湖北省武汉市武昌区黄鹤楼东路", CreationTime = Convert.ToDateTime("2009-5-18"), Latitude = 30.54393, Longitude = 114.30478, Region = context.Regions.Find(6), Employees = new List<User>{context.Users.Find(38)}},
                new Store {StoreID = 29, StoreName = "中南民大点", Address = "湖北省武汉市武昌区南湖大道政院路1号", CreationTime = Convert.ToDateTime("2008-6-5"), Latitude = 30.47893, Longitude = 114.39197, Region = context.Regions.Find(6), Employees = new List<User>{context.Users.Find(39)}},
                new Store {StoreID = 30, StoreName = "和平公园点", Address = "湖北省武汉市青山区冶金大道1号", CreationTime = Convert.ToDateTime("2008-12-31"), Latitude = 30.63134, Longitude = 114.38776, Region = context.Regions.Find(7), Employees = new List<User>{context.Users.Find(40)}},
            };
            stores.ForEach(s => context.Stores.Add(s));

            //初始化访问权限
            var allowRules = new List<AllowRule>
            {
                new AllowRule { AllowRuleID = 1, Path = "Home", Roles = new List<Role>(){context.Roles.Find(1),context.Roles.Find(2),context.Roles.Find(3),context.Roles.Find(4),context.Roles.Find(5),context.Roles.Find(6),context.Roles.Find(7)}},
                new AllowRule { AllowRuleID = 2, Path = "AssessItem", Roles = new List<Role>(){context.Roles.Find(1),context.Roles.Find(5)}},
                new AllowRule { AllowRuleID = 3, Path = "AssessReport", Roles = new List<Role>(){context.Roles.Find(1),context.Roles.Find(6)}},
                new AllowRule { AllowRuleID = 4, Path = "Category", Roles = new List<Role>(){context.Roles.Find(1),context.Roles.Find(3)}},
                new AllowRule { AllowRuleID = 5, Path = "Commodity", Roles = new List<Role>(){context.Roles.Find(1),context.Roles.Find(3)}},
                new AllowRule { AllowRuleID = 6, Path = "Region", Roles = new List<Role>(){context.Roles.Find(1),context.Roles.Find(4)}},
                new AllowRule { AllowRuleID = 7, Path = "Role", Roles = new List<Role>(){context.Roles.Find(1)}},
                new AllowRule { AllowRuleID = 8, Path = "SalesRecord", Roles = new List<Role>(){context.Roles.Find(1),context.Roles.Find(7)}},
                new AllowRule { AllowRuleID = 9, Path = "Session", Roles = new List<Role>(){context.Roles.Find(1),context.Roles.Find(2),context.Roles.Find(3),context.Roles.Find(4),context.Roles.Find(5),context.Roles.Find(6),context.Roles.Find(7)}},
                new AllowRule { AllowRuleID = 10, Path = "Store", Roles = new List<Role>(){context.Roles.Find(1),context.Roles.Find(4)}},
                new AllowRule { AllowRuleID = 11, Path = "User/Index", Roles = new List<Role>(){context.Roles.Find(5),context.Roles.Find(2)}}
            };

         
            allowRules.ForEach(s => context.AllowRules.Add(s));

            context.AllowRules.Find(1).Roles = new List<Role> 
            { 
                context.Roles.Find(1)
            };

            context.AllowRules.Find(1).Roles = new List<Role> 
            { 
                context.Roles.Find(2)
            };

            var assessGrade = new List<AssessGrade>
            {
            };
            assessGrade.ForEach(s => context.AssessGrade.Add(s));

            var assessItems = new List<AssessItem>
            {
                new AssessItem{ ItemName = "场地-现场清洁", Description = "5分：现场清洁，干净\n3分:现场有少量垃圾，或积水\n0分：现场不干净", Score = 5},
                new AssessItem{ ItemName = "场地-指定点位", Description = "5分：店门口，或人流量大的位置\n0分：远离指定点位，且未提前向我司报备", Score = 5},
                new AssessItem{ ItemName = "生动化-物资明细", Description = "10分:活动物资齐全无破损\n7分:活动生动化物资缺少一项（根据成功图象）\n4分:活动生动化物资缺少两项以上或物资破损严重\n0分:活动没有任何赠饮生动化物资", Score = 10},
                new AssessItem{ ItemName = "产品及礼品陈列", Description = "6分:产品按要求陈列且LOGO向消费者\n3分:产品双层高低陈列.但LOGO未对向消费者\n0分:产品没按要求陈列。", Score = 6},
                new AssessItem{ ItemName = "奖品储备", Description = "4分:每天赠品不少于40瓶，或优惠券储备不少于100张\n2分:奖品或优惠券储备不足上述数量\n0分:无奖品储备", Score = 4},
                new AssessItem{ ItemName = "形象", Description = "相貌/身材/皮肤/普通话各2分", Score = 8},
                new AssessItem{ ItemName = "着装", Description = "6分:促销员穿雪碧促销服,着装整洁\n3分:促销员着雪碧促销服,但头发凌乱,配饰夸张\n0分:促销员没有着工作服,穿着怪异", Score = 6},
                new AssessItem{ ItemName = "冰冻化-冰块供应", Description = "8分:冰冻设备中含冰水混合物,或冰柜正在通电降温\n4分:冰冻设备中无冰块，但有-备用冰块\n0分:冰冻设备中没有冰块,或冰柜不通电", Score = 8},
                new AssessItem{ ItemName = "冰冻化-产品温度", Description = "8分:产品温度在3摄氏度左右,手感冰凉\n4分:产品经过冰冻,但饮料温度高于八摄氏度\n0分:完全没有冰冻或饮料温度高于15摄氏度", Score = 8},
                new AssessItem{ ItemName = "工作积极性-促销员表现", Description = "20分:（检查员远观）大声叫卖（1分钟3遍）并积极主动按照标准用语要求执行,促销员声音宏亮向消费者完整陈述标准用语/3米内活动区域\n15分：积极主动向消费者完整陈述标准用语（1分钟3遍）\n10分:积极主动向消费者陈述标准用语，但标准用语不完整或陈述用语少于1分钟3遍\n5分:促销员仅向消费者提及“买赠或优惠券活动”\n0分:促销员站在促销台后，且不向消费者进行语言交流，或离岗", Score = 20},
                new AssessItem{ ItemName = "工作积极性-言语正确", Description = "10分:促销员在有消费者接近的情况下,对雪碧冰茶/公司名/成分/特点介绍，告知消费者现在进行的活动.引导消费者购买并参与活动。\n7分:促销员在有消费者接近的情况下,提及买赠活动.但未引导购买.\n4分:促销员只提及部分活动信息.\n0分:与消费者无沟通,未提及活动信息", Score = 10},
                new AssessItem{ ItemName = "工作纪律", Description = "10分:能按时开展活动,并及时解决活动中出现的问题\n5分:能按照开展活动,但不能及时改正活动中出现的问题\n0分:未按时开展活动且不能及时改正活动中的问题", Score = 10},
            };
            assessItems.ForEach(s => context.AssessItems.Add(s));

            var assessReports = new List<AssessReport>
            {
            };
            assessReports.ForEach(s => context.AssessReports.Add(s));

            var messages = new List<Message>
            {
            };
            messages.ForEach(s => context.Messages.Add(s));

            //var salesRecords = new List<SalesRecord>
            //{
            //};
            //salesRecords.ForEach(s => context.SalesRecords.Add(s));

            //销售记录查询
            DateTime startTime = new DateTime(2011, 7, 1);
            Random ran = new Random();
            var salesRecords = new List<SalesRecord>();
            for (int i = 0; i < 30; i++)
            {
                int limitSale = ran.Next(5);
                for (int n = 1; n <= 30; n++)
                {
                    for (int m = 0; m < limitSale; m++)
                    {
                        int CommodityID = ran.Next(45) + 1;
                        SalesRecord sr = new SalesRecord();
                        sr.Date = startTime;
                        sr.Commodity = context.Commodities.Find(CommodityID);
                        sr.Store = context.Stores.Find(n);
                        sr.Volume = ran.Next(100) + 1;
                        salesRecords.Add(sr);
                    }
                }
                startTime = startTime.AddDays(1);
            }
            salesRecords.ForEach(s => context.SalesRecords.Add(s));

            //保存数据到数据库
            context.SaveChanges();
            
        }
    }
}