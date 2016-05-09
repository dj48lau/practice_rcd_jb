namespace RCD.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial_tbl : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tblFileType",
                c => new
                    {
                        FileTypeID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.FileTypeID);
            
            CreateTable(
                "dbo.tblUser",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false, maxLength: 20),
                        Password = c.String(nullable: false, maxLength: 20),
                        IsActive = c.Boolean(nullable: false),
                        IsAdmin = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.UserID)
                .Index(t => t.Username, unique: true)
                .Index(t => t.Password, unique: true);
            
            CreateTable(
                "dbo.tblMetadata",
                c => new
                    {
                        MetadataID = c.Int(nullable: false, identity: true),
                        Value = c.String(nullable: false),
                        FileID = c.Int(nullable: false),
                        MetadataTypeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MetadataID)
                .ForeignKey("dbo.tblFile", t => t.FileID, cascadeDelete: true)
                .ForeignKey("dbo.tblMetadataType", t => t.MetadataTypeID, cascadeDelete: true)
                .Index(t => t.FileID)
                .Index(t => t.MetadataTypeID);
            
            CreateTable(
                "dbo.tblMetadataType",
                c => new
                    {
                        MetadataTypeID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.MetadataTypeID);
            
            CreateTable(
                "dbo.tblSetting",
                c => new
                    {
                        SettingID = c.Int(nullable: false, identity: true),
                        PeriodTime = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.SettingID);
            
            AddColumn("dbo.tblFile", "UserID", c => c.Int(nullable: false));
            AddColumn("dbo.tblFile", "FileTypeID", c => c.Int(nullable: false));
            CreateIndex("dbo.tblFile", "UserID");
            CreateIndex("dbo.tblFile", "FileTypeID");
            AddForeignKey("dbo.tblFile", "FileTypeID", "dbo.tblFileType", "FileTypeID", cascadeDelete: true);
            AddForeignKey("dbo.tblFile", "UserID", "dbo.tblUser", "UserID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tblMetadata", "MetadataTypeID", "dbo.tblMetadataType");
            DropForeignKey("dbo.tblMetadata", "FileID", "dbo.tblFile");
            DropForeignKey("dbo.tblFile", "UserID", "dbo.tblUser");
            DropForeignKey("dbo.tblFile", "FileTypeID", "dbo.tblFileType");
            DropIndex("dbo.tblMetadata", new[] { "MetadataTypeID" });
            DropIndex("dbo.tblMetadata", new[] { "FileID" });
            DropIndex("dbo.tblUser", new[] { "Password" });
            DropIndex("dbo.tblUser", new[] { "Username" });
            DropIndex("dbo.tblFile", new[] { "FileTypeID" });
            DropIndex("dbo.tblFile", new[] { "UserID" });
            DropColumn("dbo.tblFile", "FileTypeID");
            DropColumn("dbo.tblFile", "UserID");
            DropTable("dbo.tblSetting");
            DropTable("dbo.tblMetadataType");
            DropTable("dbo.tblMetadata");
            DropTable("dbo.tblUser");
            DropTable("dbo.tblFileType");
        }
    }
}
