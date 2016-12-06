namespace ITA.Schedule.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Grands",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Code = c.Int(nullable: false),
                        Name = c.String(maxLength: 400),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SecurityGroups",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Code = c.Int(nullable: false),
                        Name = c.String(maxLength: 400),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Groups",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(maxLength: 400),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SubGroups",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(maxLength: 400),
                        IsDeleted = c.Boolean(nullable: false),
                        Group_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Groups", t => t.Group_Id)
                .Index(t => t.Group_Id);
            
            CreateTable(
                "dbo.ScheduleLessons",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        LessonDate = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        LessonTime_Id = c.Guid(),
                        Room_Id = c.Guid(nullable: false),
                        Subject_Id = c.Guid(nullable: false),
                        Teacher_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.LessonTimes", t => t.LessonTime_Id)
                .ForeignKey("dbo.Rooms", t => t.Room_Id, cascadeDelete: true)
                .ForeignKey("dbo.Subjects", t => t.Subject_Id, cascadeDelete: true)
                .ForeignKey("dbo.Teachers", t => t.Teacher_Id)
                .Index(t => t.LessonTime_Id)
                .Index(t => t.Room_Id)
                .Index(t => t.Subject_Id)
                .Index(t => t.Teacher_Id);
            
            CreateTable(
                "dbo.LessonTimes",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        StartLessonTime = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        EndLessonTime = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Code = c.Int(nullable: false),
                        Name = c.String(maxLength: 400),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Rooms",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Address = c.String(nullable: false, maxLength: 400),
                        Name = c.String(maxLength: 400),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Subjects",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Code = c.Int(nullable: false),
                        Name = c.String(maxLength: 400),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(maxLength: 400),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TeacherAllTimes",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        IsBusy = c.Boolean(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        Date = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        IsDeleted = c.Boolean(nullable: false),
                        LessonTime_Id = c.Guid(),
                        Teacher_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.LessonTimes", t => t.LessonTime_Id)
                .ForeignKey("dbo.Teachers", t => t.Teacher_Id)
                .Index(t => t.LessonTime_Id)
                .Index(t => t.Teacher_Id);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(maxLength: 400),
                        IsDeleted = c.Boolean(nullable: false),
                        SubGroup_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SubGroups", t => t.SubGroup_Id)
                .Index(t => t.SubGroup_Id);
            
            CreateTable(
                "dbo.RepeatPeriods",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Code = c.Int(nullable: false),
                        Name = c.String(maxLength: 400),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Login = c.String(nullable: false, maxLength: 50),
                        Password = c.String(nullable: false, maxLength: 100),
                        IsDeleted = c.Boolean(nullable: false),
                        SecurityGroup_Id = c.Guid(),
                        Student_Id = c.Guid(),
                        Teacher_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SecurityGroups", t => t.SecurityGroup_Id)
                .ForeignKey("dbo.Students", t => t.Student_Id)
                .ForeignKey("dbo.Teachers", t => t.Teacher_Id)
                .Index(t => t.SecurityGroup_Id)
                .Index(t => t.Student_Id)
                .Index(t => t.Teacher_Id);
            
            CreateTable(
                "dbo.SecurityGroupGrands",
                c => new
                    {
                        SecurityGroup_Id = c.Guid(nullable: false),
                        Grand_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.SecurityGroup_Id, t.Grand_Id })
                .ForeignKey("dbo.SecurityGroups", t => t.SecurityGroup_Id, cascadeDelete: true)
                .ForeignKey("dbo.Grands", t => t.Grand_Id, cascadeDelete: true)
                .Index(t => t.SecurityGroup_Id)
                .Index(t => t.Grand_Id);
            
            CreateTable(
                "dbo.ScheduleLessonSubGroups",
                c => new
                    {
                        ScheduleLesson_Id = c.Guid(nullable: false),
                        SubGroup_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.ScheduleLesson_Id, t.SubGroup_Id })
                .ForeignKey("dbo.ScheduleLessons", t => t.ScheduleLesson_Id, cascadeDelete: true)
                .ForeignKey("dbo.SubGroups", t => t.SubGroup_Id, cascadeDelete: true)
                .Index(t => t.ScheduleLesson_Id)
                .Index(t => t.SubGroup_Id);
            
            CreateTable(
                "dbo.TeacherSubjects",
                c => new
                    {
                        Teacher_Id = c.Guid(nullable: false),
                        Subject_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.Teacher_Id, t.Subject_Id })
                .ForeignKey("dbo.Teachers", t => t.Teacher_Id, cascadeDelete: true)
                .ForeignKey("dbo.Subjects", t => t.Subject_Id, cascadeDelete: true)
                .Index(t => t.Teacher_Id)
                .Index(t => t.Subject_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "Teacher_Id", "dbo.Teachers");
            DropForeignKey("dbo.Users", "Student_Id", "dbo.Students");
            DropForeignKey("dbo.Users", "SecurityGroup_Id", "dbo.SecurityGroups");
            DropForeignKey("dbo.Students", "SubGroup_Id", "dbo.SubGroups");
            DropForeignKey("dbo.ScheduleLessons", "Teacher_Id", "dbo.Teachers");
            DropForeignKey("dbo.ScheduleLessons", "Subject_Id", "dbo.Subjects");
            DropForeignKey("dbo.TeacherAllTimes", "Teacher_Id", "dbo.Teachers");
            DropForeignKey("dbo.TeacherAllTimes", "LessonTime_Id", "dbo.LessonTimes");
            DropForeignKey("dbo.TeacherSubjects", "Subject_Id", "dbo.Subjects");
            DropForeignKey("dbo.TeacherSubjects", "Teacher_Id", "dbo.Teachers");
            DropForeignKey("dbo.ScheduleLessonSubGroups", "SubGroup_Id", "dbo.SubGroups");
            DropForeignKey("dbo.ScheduleLessonSubGroups", "ScheduleLesson_Id", "dbo.ScheduleLessons");
            DropForeignKey("dbo.ScheduleLessons", "Room_Id", "dbo.Rooms");
            DropForeignKey("dbo.ScheduleLessons", "LessonTime_Id", "dbo.LessonTimes");
            DropForeignKey("dbo.SubGroups", "Group_Id", "dbo.Groups");
            DropForeignKey("dbo.SecurityGroupGrands", "Grand_Id", "dbo.Grands");
            DropForeignKey("dbo.SecurityGroupGrands", "SecurityGroup_Id", "dbo.SecurityGroups");
            DropIndex("dbo.TeacherSubjects", new[] { "Subject_Id" });
            DropIndex("dbo.TeacherSubjects", new[] { "Teacher_Id" });
            DropIndex("dbo.ScheduleLessonSubGroups", new[] { "SubGroup_Id" });
            DropIndex("dbo.ScheduleLessonSubGroups", new[] { "ScheduleLesson_Id" });
            DropIndex("dbo.SecurityGroupGrands", new[] { "Grand_Id" });
            DropIndex("dbo.SecurityGroupGrands", new[] { "SecurityGroup_Id" });
            DropIndex("dbo.Users", new[] { "Teacher_Id" });
            DropIndex("dbo.Users", new[] { "Student_Id" });
            DropIndex("dbo.Users", new[] { "SecurityGroup_Id" });
            DropIndex("dbo.Students", new[] { "SubGroup_Id" });
            DropIndex("dbo.TeacherAllTimes", new[] { "Teacher_Id" });
            DropIndex("dbo.TeacherAllTimes", new[] { "LessonTime_Id" });
            DropIndex("dbo.ScheduleLessons", new[] { "Teacher_Id" });
            DropIndex("dbo.ScheduleLessons", new[] { "Subject_Id" });
            DropIndex("dbo.ScheduleLessons", new[] { "Room_Id" });
            DropIndex("dbo.ScheduleLessons", new[] { "LessonTime_Id" });
            DropIndex("dbo.SubGroups", new[] { "Group_Id" });
            DropTable("dbo.TeacherSubjects");
            DropTable("dbo.ScheduleLessonSubGroups");
            DropTable("dbo.SecurityGroupGrands");
            DropTable("dbo.Users");
            DropTable("dbo.RepeatPeriods");
            DropTable("dbo.Students");
            DropTable("dbo.TeacherAllTimes");
            DropTable("dbo.Teachers");
            DropTable("dbo.Subjects");
            DropTable("dbo.Rooms");
            DropTable("dbo.LessonTimes");
            DropTable("dbo.ScheduleLessons");
            DropTable("dbo.SubGroups");
            DropTable("dbo.Groups");
            DropTable("dbo.SecurityGroups");
            DropTable("dbo.Grands");
        }
    }
}
