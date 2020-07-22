namespace GRCLNT
{
    public enum ApiId
    {
        Conn = 0,
        AdminLogin = 1,
        AdminResetPwd = 2,
        AddDept = 3,
        DelDept = 4,
        EdtDept = 5,
        GetDepts = 6,
        AddUser = 7,
        DelUser = 8,
        EdtUser = 9,
        GetUsers = 10,
        Login = 11,
        ResetPwd = 12,
        AddDeptAuthority = 13,
        AddUserAuthority = 14,
        DelAuthority = 15,
        GetUserAuthorities = 16,
        GetDeptAuthorities = 17,
    }
    public enum ApiRes
    {
        OK = 0,
        FAILED = 1
    }
}
