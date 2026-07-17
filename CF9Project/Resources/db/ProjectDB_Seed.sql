BEGIN TRY
	BEGIN TRANSACTION;
	    -- ============================================
	-- ProjectDB - Seed Data
	-- Roles, Capabilities, Role-Capability mappings
	-- ============================================
	
	-- ============================================
	-- Insert Roles
	-- ============================================
	INSERT INTO [dbo].[Roles] ([Name])
	VALUES
	    ('ADMIN'),
	    ('EMPLOYEE'),
	    ('GAMECOMPANY'),
	    ('GAMER');
	
	-- ============================================
	-- Insert Capabilities
	-- ============================================
	INSERT INTO [dbo].[Capabilities] ([Name], [Description])
	VALUES
	    ('INSERT_GAMECOMPANY', 'Create a new game company'),
	    ('VIEW_GAMECOMPANIES', 'View game company list and details'),
	    ('VIEW_GAMECOMPANY', 'View game company'),
	    ('EDIT_GAMECOMPANY', 'Modify existing game company'),
	    ('DELETE_GAMECOMPANY', 'Remove a game company'),
	    ('VIEW_ONLY_GAMECOMPANY', 'View only own game company details'),
	    ('INSERT_GAMER', 'Create a new gamer'),
	    ('VIEW_GAMERS', 'View gamer list and details'),
	    ('VIEW_GAMER', 'View gamer'),
	    ('EDIT_GAMER', 'Modify existing gamer'),
	    ('DELETE_GAMER', 'Remove a gamer'),
	    ('VIEW_ONLY_GAMER', 'View only own gamer details'),
	    ('INSERT_GAME', 'Create a new game'),
	    ('VIEW_GAMES', 'View game list and details'),
	    ('VIEW_GAME', 'View game'),
	    ('EDIT_GAME', 'Modify existing game'),
	    ('DELETE_GAME', 'Remove a game');
	
	
	-- ============================================
	-- ADMIN: all capabilities
	-- ============================================
	INSERT INTO [dbo].[RolesCapabilities] ([RolesId], [CapabilitiesId])
	SELECT r.[Id], c.[Id]
	FROM [dbo].[Roles] r
	CROSS JOIN [dbo].[Capabilities] c
	WHERE r.[Name] = 'ADMIN';
	
	
	-- ============================================
	-- EMPLOYEE: VIEW_GAMECOMPANIES, VIEW_GAMECOMPANY,
	--           VIEW_GAMERS, VIEW_GAMER,
	--           VIEW_GAMES, VIEW_GAME
	-- ============================================
	INSERT INTO [dbo].[RolesCapabilities] ([RolesId], [CapabilitiesId])
	SELECT r.[Id], c.[Id]
	FROM [dbo].[Roles] r
	CROSS JOIN [dbo].[Capabilities] c
	WHERE r.[Name] = 'EMPLOYEE'
	  AND c.[Name] IN ('VIEW_GAMECOMPANIES', 'VIEW_GAMECOMPANY',
	                    'VIEW_GAMERS', 'VIEW_GAMER',
	                    'VIEW_GAMES', 'VIEW_GAME');
	
	
	-- ============================================
	-- GAMECOMPANY: VIEW_ONLY_GAMECOMPANY
	-- ============================================
	INSERT INTO [dbo].[RolesCapabilities] ([RolesId], [CapabilitiesId])
	SELECT r.[Id], c.[Id]
	FROM [dbo].[Roles] r
	CROSS JOIN [dbo].[Capabilities] c
	WHERE r.[Name] = 'GAMECOMPANY'
	  AND c.[Name] IN ('VIEW_ONLY_GAMECOMPANY');
	
	
	-- ============================================
	-- GAMER: VIEW_ONLY_GAMER
	-- ============================================
	INSERT INTO [dbo].[RolesCapabilities] ([RolesId], [CapabilitiesId])
	SELECT r.[Id], c.[Id]
	FROM [dbo].[Roles] r
	CROSS JOIN [dbo].[Capabilities] c
	WHERE r.[Name] = 'GAMER'
	  AND c.[Name] IN ('VIEW_ONLY_GAMER');
	    
	COMMIT TRANSACTION;
END TRY
BEGIN CATCH
    ROLLBACK TRANSACTION;
    THROW;
END CATCH;

DBCC CHECKIDENT ('dbo.Roles', RESEED, 4);
DBCC CHECKIDENT ('dbo.Capabilities', RESEED, 17); -- το επόμενο INSERT θα παράγει 18.