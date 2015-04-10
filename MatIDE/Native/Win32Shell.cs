using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MatIDE.Native
{
	public class Win32Shell
	{
		#region 構造体定義
		[StructLayout(LayoutKind.Sequential)]
		public struct SHFILEINFO
		{
			public IntPtr	hIcon;
			public int		iIcon;
			public uint		dwAttributes;
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst=260)]
			public string	szDisplayName;
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst=80)]
			public string	szTypeName;
		};
		#endregion

		#region SHGetFileInfo用のフラグ
		public const uint SHGFI_ADDOVERLAYS			= 0x000000020;	// Overlay icon
		public const uint SHGFI_ATTR_SPECIFIED		= 0x000020000;	// 
		public const uint SHGFI_ATTRIBUTES			= 0x000000800;	// get attributes
		public const uint SHGFI_DISPLAYNAME			= 0x000000200;	// get DisplayName
		public const uint SHGFI_EXETYPE				= 0x000002000;	// get type of executable file
		public const uint SHGFI_ICON				= 0x000000100;	// get icon
		public const uint SHGFI_ICONLOCATION		= 0x000001000;
		public const uint SHGFI_LARGEICON			= 0x000000000;
		public const uint SHGFI_LINKOVERLAY			= 0x000008000;
		public const uint SHGFI_OPENICON			= 0x000000002;
		public const uint SHGFI_OVERLAYINDEX		= 0x000000040;
		public const uint SHGFI_PIDL				= 0x000000008;
		public const uint SHGFI_SELECTED			= 0x000010000;
		public const uint SHGFI_SHELLICONSIZE		= 0x000000004;
		public const uint SHGFI_SMALLICON			= 0x000000001;
		public const uint SHGFI_SYSICONINDEX		= 0x000004000;
		public const uint SHGFI_TYPENAME			= 0x000000400;
		public const uint SHGFI_USEFILEATTRIBUTES	= 0x000000010;
		#endregion

		[DllImport("shell32.dll")]
		public static extern IntPtr SHGetFileInfo( string pszPath, uint dwFileAttributes, ref SHFILEINFO psfi, uint cbSizeFileInfo, uint uFlags );

		[DllImport("shell32.dll")]
		public static extern IntPtr SHGetFileInfo( IntPtr pIDL, uint dwFileAttributes, ref SHFILEINFO psfi, uint cbSizeFileInfo, uint uFlags );

		[DllImport("Shell32.DLL")]
		public static extern int SHGetSpecialFolderLocation( IntPtr hwndOwner, int nFolder, out IntPtr ppidl );

		// pidlのfree用
		[InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("00000002-0000-0000-C000-000000000046")]
		public interface IMalloc
		{
			[PreserveSig]
			IntPtr Alloc([In] int cb);
			[PreserveSig]
			IntPtr Realloc([In] IntPtr pv, [In] int cb);
			[PreserveSig]
			void Free([In] IntPtr pv);
			[PreserveSig]
			int GetSize([In] IntPtr pv);
			[PreserveSig]
			int DidAlloc(IntPtr pv);
			[PreserveSig]
			void HeapMinimize();
		}

		[DllImport("Shell32.DLL")]
		public static extern int SHGetMalloc(out IMalloc ppMalloc);

		//===================
		// SHGetSpecialFolderLocationに使用するFolderのIDの定義
		//===================
		public enum FolderID
		{
			Desktop			= 0x0000,				// Desktop
			Internet		= 0x0001,				// Internet Explorer (icon on desktop)
			Programs		= 0x0002,				// Start Menu\Programs
/*
#define CSIDL_CONTROLS                  0x0003        // My Computer\Control Panel
#define CSIDL_PRINTERS                  0x0004        // My Computer\Printers
#define CSIDL_PERSONAL                  0x0005        // My Documents
#define CSIDL_FAVORITES                 0x0006        // <user name>\Favorites
#define CSIDL_STARTUP                   0x0007        // Start Menu\Programs\Startup
#define CSIDL_RECENT                    0x0008        // <user name>\Recent
#define CSIDL_SENDTO                    0x0009        // <user name>\SendTo
#define CSIDL_BITBUCKET                 0x000a        // <desktop>\Recycle Bin
#define CSIDL_STARTMENU                 0x000b        // <user name>\Start Menu
#define CSIDL_MYDOCUMENTS               0x000c        // logical "My Documents" desktop icon
#define CSIDL_MYMUSIC                   0x000d        // "My Music" folder
#define CSIDL_MYVIDEO                   0x000e        // "My Videos" folder
#define CSIDL_DESKTOPDIRECTORY          0x0010        // <user name>\Desktop
#define CSIDL_DRIVES                    0x0011        // My Computer
#define CSIDL_NETWORK                   0x0012        // Network Neighborhood (My Network Places)
#define CSIDL_NETHOOD                   0x0013        // <user name>\nethood
#define CSIDL_FONTS                     0x0014        // windows\fonts
#define CSIDL_TEMPLATES                 0x0015
#define CSIDL_COMMON_STARTMENU          0x0016        // All Users\Start Menu
#define CSIDL_COMMON_PROGRAMS           0X0017        // All Users\Start Menu\Programs
#define CSIDL_COMMON_STARTUP            0x0018        // All Users\Startup
#define CSIDL_COMMON_DESKTOPDIRECTORY   0x0019        // All Users\Desktop
#define CSIDL_APPDATA                   0x001a        // <user name>\Application Data
#define CSIDL_PRINTHOOD                 0x001b        // <user name>\PrintHood

#ifndef CSIDL_LOCAL_APPDATA
#define CSIDL_LOCAL_APPDATA             0x001c        // <user name>\Local Settings\Applicaiton Data (non roaming)
#endif // CSIDL_LOCAL_APPDATA

#define CSIDL_ALTSTARTUP                0x001d        // non localized startup
#define CSIDL_COMMON_ALTSTARTUP         0x001e        // non localized common startup
#define CSIDL_COMMON_FAVORITES          0x001f

#ifndef _SHFOLDER_H_
#define CSIDL_INTERNET_CACHE            0x0020
#define CSIDL_COOKIES                   0x0021
#define CSIDL_HISTORY                   0x0022
#define CSIDL_COMMON_APPDATA            0x0023        // All Users\Application Data
#define CSIDL_WINDOWS                   0x0024        // GetWindowsDirectory()
#define CSIDL_SYSTEM                    0x0025        // GetSystemDirectory()
#define CSIDL_PROGRAM_FILES             0x0026        // C:\Program Files
#define CSIDL_MYPICTURES                0x0027        // C:\Program Files\My Pictures
#endif // _SHFOLDER_H_

#define CSIDL_PROFILE                   0x0028        // USERPROFILE
#define CSIDL_SYSTEMX86                 0x0029        // x86 system directory on RISC
#define CSIDL_PROGRAM_FILESX86          0x002a        // x86 C:\Program Files on RISC

#ifndef _SHFOLDER_H_
#define CSIDL_PROGRAM_FILES_COMMON      0x002b        // C:\Program Files\Common
#endif // _SHFOLDER_H_

#define CSIDL_PROGRAM_FILES_COMMONX86   0x002c        // x86 Program Files\Common on RISC
#define CSIDL_COMMON_TEMPLATES          0x002d        // All Users\Templates

#ifndef _SHFOLDER_H_
#define CSIDL_COMMON_DOCUMENTS          0x002e        // All Users\Documents
#define CSIDL_COMMON_ADMINTOOLS         0x002f        // All Users\Start Menu\Programs\Administrative Tools
#define CSIDL_ADMINTOOLS                0x0030        // <user name>\Start Menu\Programs\Administrative Tools
#endif // _SHFOLDER_H_

#define CSIDL_CONNECTIONS               0x0031        // Network and Dial-up Connections
#define CSIDL_COMMON_MUSIC              0x0035        // All Users\My Music
#define CSIDL_COMMON_PICTURES           0x0036        // All Users\My Pictures
#define CSIDL_COMMON_VIDEO              0x0037        // All Users\My Video
#define CSIDL_RESOURCES                 0x0038        // Resource Direcotry

#ifndef _SHFOLDER_H_
#define CSIDL_RESOURCES_LOCALIZED       0x0039        // Localized Resource Direcotry
#endif // _SHFOLDER_H_

#define CSIDL_COMMON_OEM_LINKS          0x003a        // Links to All Users OEM specific apps
#define CSIDL_CDBURN_AREA               0x003b        // USERPROFILE\Local Settings\Application Data\Microsoft\CD Burning
// unused                               0x003c
#define CSIDL_COMPUTERSNEARME           0x003d        // Computers Near Me (computered from Workgroup membership)

#ifndef _SHFOLDER_H_
#define CSIDL_FLAG_CREATE               0x8000        // combine with CSIDL_ value to force folder creation in SHGetFolderPath()
#endif // _SHFOLDER_H_

#define CSIDL_FLAG_DONT_VERIFY          0x4000        // combine with CSIDL_ value to return an unverified folder path
#define CSIDL_FLAG_NO_ALIAS             0x1000        // combine with CSIDL_ value to insure non-alias versions of the pidl
#define CSIDL_FLAG_PER_USER_INIT        0x0800        // combine with CSIDL_ value to indicate per-user init (eg. upgrade)
#define CSIDL_FLAG_MASK                 0xFF00        // mask for all possible flag values

*/
			Printers = 0x0004,  
			MyDocuments = 0x0005,  
			Favorites = 0x0006,  
			Recent = 0x0008,  
			SendTo = 0x0009,  
			StartMenu = 0x000b,  
			MyComputer = 0x0011,  
			NetworkNeighborhood = 0x0012,  
			Templates = 0x0015,  
			MyPictures = 0x0027,  
			NetAndDialUpConnections = 0x0031,  
		}

		public static readonly Guid	FOLDERID_ComputerFolder		= new Guid("{0AC0837C-BBF8-452A-850D-79D08E667CA7}");
		public static readonly Guid	FOLDERID_Desktop			= new Guid("{B4BFCC3A-DB2C-424C-B029-7FE99A87C641}");
		public static readonly Guid	FOLDERID_Documents			= new Guid("{FDD39AD0-238F-46AF-ADB4-6C85480369C7}");
		public static readonly Guid	FOLDERID_DocumentsLibrary	= new Guid("{7B0DB17D-9CD2-4A93-9733-46CC89022E7C}");
		public static readonly Guid	FOLDERID_Downloads			= new Guid("{374DE290-123F-4565-9164-39C4925E467B}");
		public static readonly Guid	FOLDERID_Favorites			= new Guid("{1777F761-68AD-4D8A-87BD-30B759FA33DD}");
		public static readonly Guid FOLDERID_Pictures			= new Guid("{33E28130-4E1E-4676-835A-98395C3BC3BB}");
		public static readonly Guid FOLDERID_Videos				= new Guid("{18989B1D-99B5-455B-841C-AB7C74E4DDFC}");
		public static readonly Guid FOLDERID_Music				= new Guid("{4BD8D571-6D19-48D3-BE97-422220080E43}");
		public static readonly Guid FOLDERID_Links				= new Guid("{bfb9d5e0-c6a9-404c-b2b2-ae6db6af4968}");
		/*
		public static readonly Guid FOLDERID_AccountPictures		{008ca0b1-55b4-4c56-b8a8-4de4b299d3be}
		public static readonly Guid FOLDERID_AddNewPrograms			{de61d971-5ebc-4f02-a3a9-6c82895e5c04}
		public static readonly Guid FOLDERID_AdminTools				{724EF170-A42D-4FEF-9F26-B60E846FBA4F}
		public static readonly Guid FOLDERID_ApplicationShortcuts	{A3918781-E5F2-4890-B3D9-A7E54332328C}
		public static readonly Guid FOLDERID_AppsFolder				{1e87508d-89c2-42f0-8a7e-645a0f50ca58}
		public static readonly Guid FOLDERID_AppUpdates				{a305ce99-f527-492b-8b1a-7e76fa98d6e4}
		public static readonly Guid FOLDERID_CameraRoll				{AB5FB87B-7CE2-4F83-915D-550846C9537B}
		public static readonly Guid FOLDERID_CDBurning				{9E52AB10-F80D-49DF-ACB8-4330F5687855}
		public static readonly Guid FOLDERID_ChangeRemovePrograms	{df7266ac-9274-4867-8d55-3bd661de872d}
		public static readonly Guid FOLDERID_CommonAdminTools		{D0384E7D-BAC3-4797-8F14-CBA229B392B5}
		public static readonly Guid FOLDERID_CommonOEMLinks			{C1BAE2D0-10DF-4334-BEDD-7AA20B227A9D}
		public static readonly Guid FOLDERID_CommonPrograms			{0139D44E-6AFE-49F2-8690-3DAFCAE6FFB8}
		public static readonly Guid FOLDERID_CommonStartMenu		{A4115719-D62E-491D-AA7C-E74B8BE3B067}
		public static readonly Guid FOLDERID_CommonStartup			{82A5EA35-D9CD-47C5-9629-E15D2F714E6E}
		public static readonly Guid FOLDERID_CommonTemplates		{B94237E7-57AC-4347-9151-B08C6C32D1F7}
		public static readonly Guid FOLDERID_ComputerFolder			{0AC0837C-BBF8-452A-850D-79D08E667CA7}
		public static readonly Guid FOLDERID_ConflictFolder			{4bfefb45-347d-4006-a5be-ac0cb0567192}
		public static readonly Guid FOLDERID_ConnectionsFolder		{6F0CD92B-2E97-45D1-88FF-B0D186B8DEDD}
		public static readonly Guid FOLDERID_Contacts				{56784854-C6CB-462b-8169-88E350ACB882}
		public static readonly Guid FOLDERID_ControlPanelFolder		{82A74AEB-AEB4-465C-A014-D097EE346D63}
		public static readonly Guid FOLDERID_Cookies				{2B0F765D-C0E9-4171-908E-08A611B84FF6}
		public static readonly Guid FOLDERID_Desktop				{B4BFCC3A-DB2C-424C-B029-7FE99A87C641}
		public static readonly Guid FOLDERID_DeviceMetadataStore	{5CE4A5E9-E4EB-479D-B89F-130C02886155}
		public static readonly Guid FOLDERID_Documents				{FDD39AD0-238F-46AF-ADB4-6C85480369C7}
		public static readonly Guid FOLDERID_DocumentsLibrary		{7B0DB17D-9CD2-4A93-9733-46CC89022E7C}
		public static readonly Guid FOLDERID_Downloads				{374DE290-123F-4565-9164-39C4925E467B}
		public static readonly Guid FOLDERID_Favorites				{1777F761-68AD-4D8A-87BD-30B759FA33DD}
		public static readonly Guid FOLDERID_Fonts					{FD228CB7-AE11-4AE3-864C-16F3910AB8FE}
		public static readonly Guid FOLDERID_Games					{CAC52C1A-B53D-4edc-92D7-6B2E8AC19434}
		public static readonly Guid FOLDERID_GameTasks				{054FAE61-4DD8-4787-80B6-090220C4B700}
		public static readonly Guid FOLDERID_History				{D9DC8A3B-B784-432E-A781-5A1130A75963}
		public static readonly Guid FOLDERID_HomeGroup				{52528A6B-B9E3-4ADD-B60D-588C2DBA842D}
		public static readonly Guid FOLDERID_HomeGroupCurrentUser	{9B74B6A3-0DFD-4f11-9E78-5F7800F2E772}
		public static readonly Guid FOLDERID_ImplicitAppShortcuts	{BCB5256F-79F6-4CEE-B725-DC34E402FD46}
		public static readonly Guid FOLDERID_InternetCache			{352481E8-33BE-4251-BA85-6007CAEDCF9D}
		public static readonly Guid FOLDERID_InternetFolder			{4D9F7874-4E0C-4904-967B-40B0D20C3E4B}
		public static readonly Guid FOLDERID_Libraries				{1B3EA5DC-B587-4786-B4EF-BD1DC332AEAE}
		public static readonly Guid FOLDERID_Links					{bfb9d5e0-c6a9-404c-b2b2-ae6db6af4968}
		public static readonly Guid FOLDERID_LocalAppData			{F1B32785-6FBA-4FCF-9D55-7B8E7F157091}
		public static readonly Guid FOLDERID_LocalAppDataLow		{A520A1A4-1780-4FF6-BD18-167343C5AF16}
		public static readonly Guid FOLDERID_LocalizedResourcesDir	{2A00375E-224C-49DE-B8D1-440DF7EF3DDC}
		public static readonly Guid FOLDERID_Music					{4BD8D571-6D19-48D3-BE97-422220080E43}
		public static readonly Guid FOLDERID_MusicLibrary			{2112AB0A-C86A-4FFE-A368-0DE96E47012E}
		public static readonly Guid FOLDERID_NetHood				{C5ABBF53-E17F-4121-8900-86626FC2C973}
		public static readonly Guid FOLDERID_NetworkFolder			{D20BEEC4-5CA8-4905-AE3B-BF251EA09B53}
		public static readonly Guid FOLDERID_OriginalImages			{2C36C0AA-5812-4b87-BFD0-4CD0DFB19B39}
		public static readonly Guid FOLDERID_PhotoAlbums			{69D2CF90-FC33-4FB7-9A0C-EBB0F0FCB43C}
		public static readonly Guid FOLDERID_PicturesLibrary		{A990AE9F-A03B-4E80-94BC-9912D7504104}
		public static readonly Guid FOLDERID_Pictures				{33E28130-4E1E-4676-835A-98395C3BC3BB}
		public static readonly Guid FOLDERID_Playlists				{DE92C1C7-837F-4F69-A3BB-86E631204A23}
		public static readonly Guid FOLDERID_PrintersFolder			{76FC4E2D-D6AD-4519-A663-37BD56068185}
		public static readonly Guid FOLDERID_PrintHood				{9274BD8D-CFD1-41C3-B35E-B13F55A758F4}
		public static readonly Guid FOLDERID_Profile				{5E6C858F-0E22-4760-9AFE-EA3317B67173}
		public static readonly Guid FOLDERID_ProgramData			{62AB5D82-FDC1-4DC3-A9DD-070D1D495D97}
		public static readonly Guid FOLDERID_ProgramFiles			{905e63b6-c1bf-494e-b29c-65b732d3d21a}
		public static readonly Guid FOLDERID_ProgramFilesX64		{6D809377-6AF0-444b-8957-A3773F02200E}
		public static readonly Guid FOLDERID_ProgramFilesX86		{7C5A40EF-A0FB-4BFC-874A-C0F2E0B9FA8E}
		public static readonly Guid FOLDERID_ProgramFilesCommon		{F7F1ED05-9F6D-47A2-AAAE-29D317C6F066}
		public static readonly Guid FOLDERID_ProgramFilesCommonX64	{6365D5A7-0F0D-45E5-87F6-0DA56B6A4F7D}
		public static readonly Guid FOLDERID_ProgramFilesCommonX86	{DE974D24-D9C6-4D3E-BF91-F4455120B917}
		public static readonly Guid FOLDERID_Programs				{A77F5D77-2E2B-44C3-A6A2-ABA601054A51}
		public static readonly Guid FOLDERID_Public					{DFDF76A2-C82A-4D63-906A-5644AC457385}
		public static readonly Guid FOLDERID_PublicDesktop			{C4AA340D-F20F-4863-AFEF-F87EF2E6BA25}
		public static readonly Guid FOLDERID_PublicDocuments		{ED4824AF-DCE4-45A8-81E2-FC7965083634}
		public static readonly Guid FOLDERID_PublicDownloads		{3D644C9B-1FB8-4f30-9B45-F670235F79C0}
		public static readonly Guid FOLDERID_PublicGameTasks		{DEBF2536-E1A8-4c59-B6A2-414586476AEA}
		public static readonly Guid FOLDERID_PublicLibraries		{48DAF80B-E6CF-4F4E-B800-0E69D84EE384}
		public static readonly Guid FOLDERID_PublicMusic			{3214FAB5-9757-4298-BB61-92A9DEAA44FF}
		public static readonly Guid FOLDERID_PublicPictures			{B6EBFB86-6907-413C-9AF7-4FC2ABF07CC5}
		public static readonly Guid FOLDERID_PublicRingtones		{E555AB60-153B-4D17-9F04-A5FE99FC15EC}
		public static readonly Guid FOLDERID_PublicUserTiles		{0482af6c-08f1-4c34-8c90-e17ec98b1e17}
		public static readonly Guid FOLDERID_PublicVideos			{2400183A-6185-49FB-A2D8-4A392A602BA3}
		public static readonly Guid FOLDERID_QuickLaunch			{52a4f021-7b75-48a9-9f6b-4b87a210bc8f}
		public static readonly Guid FOLDERID_Recent					{AE50C081-EBD2-438A-8655-8A092E34987A}
		public static readonly Guid FOLDERID_RecordedTVLibrary		{1A6FDBA2-F42D-4358-A798-B74D745926C5}
		public static readonly Guid FOLDERID_RecycleBinFolder		{B7534046-3ECB-4C18-BE4E-64CD4CB7D6AC}
		public static readonly Guid FOLDERID_ResourceDir			{8AD10C31-2ADB-4296-A8F7-E4701232C972}
		public static readonly Guid FOLDERID_Ringtones				{C870044B-F49E-4126-A9C3-B52A1FF411E8}
		public static readonly Guid FOLDERID_RoamingAppData			{3EB685DB-65F9-4CF6-A03A-E3EF65729F3D}
		public static readonly Guid FOLDERID_RoamedTileImages		{AAA8D5A5-F1D6-4259-BAA8-78E7EF60835E}
		public static readonly Guid FOLDERID_RoamingTiles			{00BCFC5A-ED94-4e48-96A1-3F6217F21990}
		public static readonly Guid FOLDERID_SampleMusic			{B250C668-F57D-4EE1-A63C-290EE7D1AA1F}
		public static readonly Guid FOLDERID_SamplePictures			{C4900540-2379-4C75-844B-64E6FAF8716B}
		public static readonly Guid FOLDERID_SamplePlaylists		{15CA69B3-30EE-49C1-ACE1-6B5EC372AFB5}
		public static readonly Guid FOLDERID_SampleVideos			{859EAD94-2E85-48AD-A71A-0969CB56A6CD}
		public static readonly Guid FOLDERID_SavedGames				{4C5C32FF-BB9D-43b0-B5B4-2D72E54EAAA4}
		public static readonly Guid FOLDERID_SavedSearches			{7d1d3a04-debb-4115-95cf-2f29da2920da}
		public static readonly Guid FOLDERID_Screenshots			{b7bede81-df94-4682-a7d8-57a52620b86f} 
		public static readonly Guid FOLDERID_SEARCH_CSC				{ee32e446-31ca-4aba-814f-a5ebd2fd6d5e}
		public static readonly Guid FOLDERID_SearchHistory			{0D4C3DB6-03A3-462F-A0E6-08924C41B5D4}
		public static readonly Guid FOLDERID_SearchHome				{190337d1-b8ca-4121-a639-6d472d16972a}
		public static readonly Guid FOLDERID_SEARCH_MAPI			{98ec0e18-2098-4d44-8644-66979315a281}
		public static readonly Guid FOLDERID_SearchTemplates		{7E636BFE-DFA9-4D5E-B456-D7B39851D8A9}
		public static readonly Guid FOLDERID_SendTo					{8983036C-27C0-404B-8F08-102D10DCFD74}
		public static readonly Guid FOLDERID_SidebarDefaultParts	{7B396E54-9EC5-4300-BE0A-2482EBAE1A26}
		public static readonly Guid FOLDERID_SidebarParts			{A75D362E-50FC-4fb7-AC2C-A8BEAA314493}
		public static readonly Guid FOLDERID_SkyDrive				{A52BBA46-E9E1-435f-B3D9-28DAA648C0F6}
		public static readonly Guid FOLDERID_SkyDriveCameraRoll		{767E6811-49CB-4273-87C2-20F355E1085B}
		public static readonly Guid FOLDERID_SkyDriveDocuments		{24D89E24-2F19-4534-9DDE-6A6671FBB8FE}
		public static readonly Guid FOLDERID_SkyDrivePictures		{339719B5-8C47-4894-94C2-D8F77ADD44A6}
		public static readonly Guid FOLDERID_StartMenu				{625B53C3-AB48-4EC1-BA1F-A1EF4146FC19}
		public static readonly Guid FOLDERID_Startup				{B97D20BB-F46A-4C97-BA10-5E3608430854}
		public static readonly Guid FOLDERID_SyncManagerFolder		{43668BF8-C14E-49B2-97C9-747784D784B7}
		public static readonly Guid FOLDERID_SyncResultsFolder		{289a9a43-be44-4057-a41b-587a76d7e7f9}
		public static readonly Guid FOLDERID_SyncSetupFolder		{0F214138-B1D3-4a90-BBA9-27CBC0C5389A}
		public static readonly Guid FOLDERID_System					{1AC14E77-02E7-4E5D-B744-2EB1AE5198B7}
		public static readonly Guid FOLDERID_SystemX86				{D65231B0-B2F1-4857-A4CE-A8E7C6EA7D27}
		public static readonly Guid FOLDERID_Templates				{A63293E8-664E-48DB-A079-DF759E0509F7}
		public static readonly Guid FOLDERID_TreeProperties			{9E3995AB-1F9C-4F13-B827-48B24B6C7174}
		public static readonly Guid FOLDERID_UserProfiles			{0762D272-C50A-4BB0-A382-697DCD729B80}
		public static readonly Guid FOLDERID_UserProgramFiles		{5CD7AEE2-2219-4A67-B85D-6C9CE15660CB}
		public static readonly Guid FOLDERID_UserProgramFilesCommon	{BCBD3057-CA5C-4622-B42D-BC56DB0AE516}
		public static readonly Guid FOLDERID_UsersFiles				{f3ce0f7c-4901-4acc-8648-d5d44b04ef8f}
		public static readonly Guid FOLDERID_UsersLibraries			{A302545D-DEFF-464b-ABE8-61C8648D939B}
		public static readonly Guid FOLDERID_Videos					{18989B1D-99B5-455B-841C-AB7C74E4DDFC}
		public static readonly Guid FOLDERID_VideosLibrary			{491E922F-5643-4AF4-A7EB-4E7A138D8174}
		public static readonly Guid FOLDERID_Windows				{F38BF404-1D43-42F2-9305-67DE0B28FC23}
		*/
 
		[DllImport("shell32.dll")]
		public static extern int SHGetKnownFolderPath( [MarshalAs(UnmanagedType.LPStruct)] Guid rfid, uint dwFlags, IntPtr hToken, out IntPtr pszPath );

		[DllImport("shell32.dll")]
		public static extern int SHGetKnownFolderIDList( [MarshalAs(UnmanagedType.LPStruct)] Guid rfid, uint dwFlags, IntPtr hToken, out IntPtr ppidl );

		public static void GetFolderInfo( string fullPath, out string DisplayName, out string TypeName )
		{
			IntPtr					pidRoot = IntPtr.Zero;
			Win32Shell.SHFILEINFO	shInfo = new Win32Shell.SHFILEINFO();

			SHGetFileInfo( fullPath, 0, ref shInfo, (uint)Marshal.SizeOf(shInfo), SHGFI_DISPLAYNAME|SHGFI_TYPENAME );
			DisplayName	= shInfo.szDisplayName;
			TypeName	= shInfo.szTypeName;
			if ( pidRoot != IntPtr.Zero ){
				Win32Shell.IMalloc	malloc;
				Win32Shell.SHGetMalloc( out malloc );
				malloc.Free( pidRoot );
			}
		}

		public static void GetFolderInfo( Guid guid, out string DisplayName, out string FullPath )
		{
			IntPtr					pidRoot = IntPtr.Zero;
			IntPtr					pPath = IntPtr.Zero;
			Win32Shell.SHFILEINFO	shInfo = new Win32Shell.SHFILEINFO();

			Win32Shell.SHGetKnownFolderIDList( guid, 0, IntPtr.Zero, out pidRoot );
			Win32Shell.SHGetFileInfo( pidRoot, 0, ref shInfo, (uint)Marshal.SizeOf(shInfo), SHGFI_DISPLAYNAME|SHGFI_TYPENAME|SHGFI_PIDL );

			DisplayName	= shInfo.szDisplayName;
			if ( pidRoot != IntPtr.Zero ){
				Win32Shell.IMalloc	malloc;
				Win32Shell.SHGetMalloc( out malloc );
				malloc.Free( pidRoot );
			}
			SHGetKnownFolderPath( guid, 0, IntPtr.Zero, out pPath );
			FullPath = Marshal.PtrToStringUni(pPath);
			Marshal.FreeCoTaskMem(pPath);
		}

		public static string GetFolderPath( Guid guid )
		{
			IntPtr	pPath = IntPtr.Zero;
			string	path;

			SHGetKnownFolderPath( guid, 0, IntPtr.Zero, out pPath );
			path = Marshal.PtrToStringUni(pPath);
			Marshal.FreeCoTaskMem(pPath);
			return path;
		}
	}
}
