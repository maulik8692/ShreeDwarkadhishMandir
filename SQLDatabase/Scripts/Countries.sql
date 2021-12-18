﻿/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM $(TableName)					
--------------------------------------------------------------------------------------
*/
if not exists(select * from dbo.Countries)
Begin
SET IDENTITY_INSERT dbo.Countries ON 

INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (1, N'AF', N'Afghanistan', 93, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (2, N'AL', N'Albania', 355, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (3, N'DZ', N'Algeria', 213, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (4, N'AS', N'American Samoa', 1684, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (5, N'AD', N'Andorra', 376, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (6, N'AO', N'Angola', 244, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (7, N'AI', N'Anguilla', 1264, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (8, N'AQ', N'Antarctica', 0, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (9, N'AG', N'Antigua And Barbuda', 1268, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (10, N'AR', N'Argentina', 54, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (11, N'AM', N'Armenia', 374, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (12, N'AW', N'Aruba', 297, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (13, N'AU', N'Australia', 61, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (14, N'AT', N'Austria', 43, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (15, N'AZ', N'Azerbaijan', 994, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (16, N'BS', N'Bahamas The', 1242, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (17, N'BH', N'Bahrain', 973, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (18, N'BD', N'Bangladesh', 880, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (19, N'BB', N'Barbados', 1246, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (20, N'BY', N'Belarus', 375, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (21, N'BE', N'Belgium', 32, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (22, N'BZ', N'Belize', 501, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (23, N'BJ', N'Benin', 229, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (24, N'BM', N'Bermuda', 1441, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (25, N'BT', N'Bhutan', 975, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (26, N'BO', N'Bolivia', 591, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (27, N'BA', N'Bosnia and Herzegovina', 387, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (28, N'BW', N'Botswana', 267, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (29, N'BV', N'Bouvet Island', 0, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (30, N'BR', N'Brazil', 55, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (31, N'IO', N'British Indian Ocean Territory', 246, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (32, N'BN', N'Brunei', 673, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (33, N'BG', N'Bulgaria', 359, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (34, N'BF', N'Burkina Faso', 226, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (35, N'BI', N'Burundi', 257, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (36, N'KH', N'Cambodia', 855, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (37, N'CM', N'Cameroon', 237, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (38, N'CA', N'Canada', 1, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (39, N'CV', N'Cape Verde', 238, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (40, N'KY', N'Cayman Islands', 1345, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (41, N'CF', N'Central African Republic', 236, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (42, N'TD', N'Chad', 235, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (43, N'CL', N'Chile', 56, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (44, N'CN', N'China', 86, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (45, N'CX', N'Christmas Island', 61, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (46, N'CC', N'Cocos (Keeling) Islands', 672, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (47, N'CO', N'Colombia', 57, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (48, N'KM', N'Comoros', 269, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (49, N'CG', N'Republic Of The Congo', 242, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (50, N'CD', N'Democratic Republic Of The Congo', 242, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (51, N'CK', N'Cook Islands', 682, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (52, N'CR', N'Costa Rica', 506, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (53, N'CI', N'Cote D''Ivoire (Ivory Coast)', 225, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (54, N'HR', N'Croatia (Hrvatska)', 385, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (55, N'CU', N'Cuba', 53, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (56, N'CY', N'Cyprus', 357, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (57, N'CZ', N'Czech Republic', 420, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (58, N'DK', N'Denmark', 45, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (59, N'DJ', N'Djibouti', 253, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (60, N'DM', N'Dominica', 1767, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (61, N'DO', N'Dominican Republic', 1809, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (62, N'TP', N'East Timor', 670, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (63, N'EC', N'Ecuador', 593, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (64, N'EG', N'Egypt', 20, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (65, N'SV', N'El Salvador', 503, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (66, N'GQ', N'Equatorial Guinea', 240, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (67, N'ER', N'Eritrea', 291, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (68, N'EE', N'Estonia', 372, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (69, N'ET', N'Ethiopia', 251, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (70, N'XA', N'External Territories of Australia', 61, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (71, N'FK', N'Falkland Islands', 500, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (72, N'FO', N'Faroe Islands', 298, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (73, N'FJ', N'Fiji Islands', 679, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (74, N'FI', N'Finland', 358, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (75, N'FR', N'France', 33, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (76, N'GF', N'French Guiana', 594, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (77, N'PF', N'French Polynesia', 689, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (78, N'TF', N'French Southern Territories', 0, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (79, N'GA', N'Gabon', 241, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (80, N'GM', N'Gambia The', 220, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (81, N'GE', N'Georgia', 995, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (82, N'DE', N'Germany', 49, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (83, N'GH', N'Ghana', 233, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (84, N'GI', N'Gibraltar', 350, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (85, N'GR', N'Greece', 30, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (86, N'GL', N'Greenland', 299, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (87, N'GD', N'Grenada', 1473, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (88, N'GP', N'Guadeloupe', 590, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (89, N'GU', N'Guam', 1671, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (90, N'GT', N'Guatemala', 502, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (91, N'XU', N'Guernsey and Alderney', 44, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (92, N'GN', N'Guinea', 224, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (93, N'GW', N'Guinea-Bissau', 245, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (94, N'GY', N'Guyana', 592, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (95, N'HT', N'Haiti', 509, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (96, N'HM', N'Heard and McDonald Islands', 0, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (97, N'HN', N'Honduras', 504, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (98, N'HK', N'Hong Kong S.A.R.', 852, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (99, N'HU', N'Hungary', 36, 1)

INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (100, N'IS', N'Iceland', 354, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (101, N'IN', N'India', 91, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (102, N'ID', N'Indonesia', 62, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (103, N'IR', N'Iran', 98, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (104, N'IQ', N'Iraq', 964, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (105, N'IE', N'Ireland', 353, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (106, N'IL', N'Israel', 972, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (107, N'IT', N'Italy', 39, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (108, N'JM', N'Jamaica', 1876, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (109, N'JP', N'Japan', 81, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (110, N'XJ', N'Jersey', 44, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (111, N'JO', N'Jordan', 962, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (112, N'KZ', N'Kazakhstan', 7, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (113, N'KE', N'Kenya', 254, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (114, N'KI', N'Kiribati', 686, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (115, N'KP', N'Korea North', 850, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (116, N'KR', N'Korea South', 82, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (117, N'KW', N'Kuwait', 965, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (118, N'KG', N'Kyrgyzstan', 996, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (119, N'LA', N'Laos', 856, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (120, N'LV', N'Latvia', 371, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (121, N'LB', N'Lebanon', 961, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (122, N'LS', N'Lesotho', 266, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (123, N'LR', N'Liberia', 231, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (124, N'LY', N'Libya', 218, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (125, N'LI', N'Liechtenstein', 423, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (126, N'LT', N'Lithuania', 370, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (127, N'LU', N'Luxembourg', 352, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (128, N'MO', N'Macau S.A.R.', 853, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (129, N'MK', N'Macedonia', 389, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (130, N'MG', N'Madagascar', 261, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (131, N'MW', N'Malawi', 265, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (132, N'MY', N'Malaysia', 60, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (133, N'MV', N'Maldives', 960, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (134, N'ML', N'Mali', 223, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (135, N'MT', N'Malta', 356, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (136, N'XM', N'Man (Isle of)', 44, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (137, N'MH', N'Marshall Islands', 692, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (138, N'MQ', N'Martinique', 596, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (139, N'MR', N'Mauritania', 222, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (140, N'MU', N'Mauritius', 230, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (141, N'YT', N'Mayotte', 269, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (142, N'MX', N'Mexico', 52, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (143, N'FM', N'Micronesia', 691, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (144, N'MD', N'Moldova', 373, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (145, N'MC', N'Monaco', 377, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (146, N'MN', N'Mongolia', 976, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (147, N'MS', N'Montserrat', 1664, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (148, N'MA', N'Morocco', 212, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (149, N'MZ', N'Mozambique', 258, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (150, N'MM', N'Myanmar', 95, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (151, N'NA', N'Namibia', 264, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (152, N'NR', N'Nauru', 674, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (153, N'NP', N'Nepal', 977, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (154, N'AN', N'Netherlands Antilles', 599, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (155, N'NL', N'Netherlands The', 31, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (156, N'NC', N'New Caledonia', 687, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (157, N'NZ', N'New Zealand', 64, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (158, N'NI', N'Nicaragua', 505, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (159, N'NE', N'Niger', 227, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (160, N'NG', N'Nigeria', 234, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (161, N'NU', N'Niue', 683, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (162, N'NF', N'Norfolk Island', 672, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (163, N'MP', N'Northern Mariana Islands', 1670, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (164, N'NO', N'Norway', 47, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (165, N'OM', N'Oman', 968, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (166, N'PK', N'Pakistan', 92, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (167, N'PW', N'Palau', 680, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (168, N'PS', N'Palestinian Territory Occupied', 970, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (169, N'PA', N'Panama', 507, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (170, N'PG', N'Papua new Guinea', 675, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (171, N'PY', N'Paraguay', 595, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (172, N'PE', N'Peru', 51, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (173, N'PH', N'Philippines', 63, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (174, N'PN', N'Pitcairn Island', 0, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (175, N'PL', N'Poland', 48, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (176, N'PT', N'Portugal', 351, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (177, N'PR', N'Puerto Rico', 1787, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (178, N'QA', N'Qatar', 974, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (179, N'RE', N'Reunion', 262, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (180, N'RO', N'Romania', 40, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (181, N'RU', N'Russia', 70, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (182, N'RW', N'Rwanda', 250, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (183, N'SH', N'Saint Helena', 290, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (184, N'KN', N'Saint Kitts And Nevis', 1869, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (185, N'LC', N'Saint Lucia', 1758, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (186, N'PM', N'Saint Pierre and Miquelon', 508, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (187, N'VC', N'Saint Vincent And The Grenadines', 1784, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (188, N'WS', N'Samoa', 684, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (189, N'SM', N'San Marino', 378, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (190, N'ST', N'Sao Tome and Principe', 239, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (191, N'SA', N'Saudi Arabia', 966, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (192, N'SN', N'Senegal', 221, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (193, N'RS', N'Serbia', 381, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (194, N'SC', N'Seychelles', 248, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (195, N'SL', N'Sierra Leone', 232, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (196, N'SG', N'Singapore', 65, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (197, N'SK', N'Slovakia', 421, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (198, N'SI', N'Slovenia', 386, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (199, N'XG', N'Smaller Territories of the UK', 44, 1)

INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (200, N'SB', N'Solomon Islands', 677, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (201, N'SO', N'Somalia', 252, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (202, N'ZA', N'South Africa', 27, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (203, N'GS', N'South Georgia', 0, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (204, N'SS', N'South Sudan', 211, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (205, N'ES', N'Spain', 34, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (206, N'LK', N'Sri Lanka', 94, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (207, N'SD', N'Sudan', 249, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (208, N'SR', N'Suriname', 597, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (209, N'SJ', N'Svalbard And Jan Mayen Islands', 47, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (210, N'SZ', N'Swaziland', 268, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (211, N'SE', N'Sweden', 46, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (212, N'CH', N'Switzerland', 41, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (213, N'SY', N'Syria', 963, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (214, N'TW', N'Taiwan', 886, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (215, N'TJ', N'Tajikistan', 992, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (216, N'TZ', N'Tanzania', 255, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (217, N'TH', N'Thailand', 66, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (218, N'TG', N'Togo', 228, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (219, N'TK', N'Tokelau', 690, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (220, N'TO', N'Tonga', 676, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (221, N'TT', N'Trinidad And Tobago', 1868, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (222, N'TN', N'Tunisia', 216, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (223, N'TR', N'Turkey', 90, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (224, N'TM', N'Turkmenistan', 7370, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (225, N'TC', N'Turks And Caicos Islands', 1649, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (226, N'TV', N'Tuvalu', 688, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (227, N'UG', N'Uganda', 256, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (228, N'UA', N'Ukraine', 380, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (229, N'AE', N'United Arab Emirates', 971, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (230, N'GB', N'United Kingdom', 44, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (231, N'US', N'United States', 1, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (232, N'UM', N'United States Minor Outlying Islands', 1, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (233, N'UY', N'Uruguay', 598, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (234, N'UZ', N'Uzbekistan', 998, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (235, N'VU', N'Vanuatu', 678, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (236, N'VA', N'Vatican City State (Holy See)', 39, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (237, N'VE', N'Venezuela', 58, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (238, N'VN', N'Vietnam', 84, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (239, N'VG', N'Virgin Islands (British)', 1284, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (240, N'VI', N'Virgin Islands (US)', 1340, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (241, N'WF', N'Wallis And Futuna Islands', 681, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (242, N'EH', N'Western Sahara', 212, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (243, N'YE', N'Yemen', 967, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (244, N'YU', N'Yugoslavia', 38, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (245, N'ZM', N'Zambia', 260, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (246, N'ZW', N'Zimbabwe', 263, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (247, N'BN', N'Brunei Darussalam', NULL, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (248, N'BO', N'Bolivia, Plurinational State of', NULL, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (249, N'BS', N'Bahamas', NULL, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (250, N'CD', N'Congo, The Democratic Republic of the', NULL, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (251, N'CG', N'Congo', NULL, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (252, N'CI', N'Côte d''Ivoire', NULL, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (253, N'FJ', N'Fiji', NULL, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (254, N'FK', N'Falkland Islands (Malvinas)', NULL, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (255, N'FM', N'Micronesia, Federated States of', NULL, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (256, N'GM', N'Gambia', NULL, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (257, N'GS', N'South Georgia and the South Sandwich Islands', NULL, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (258, N'HK', N'Hong Kong ', NULL, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (259, N'HM', N'Heard Island and McDonald Islands', NULL, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (260, N'HR', N'Croatia', NULL, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (261, N'IR', N'Iran, Islamic Republic of', NULL, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (262, N'KP', N'Korea, Democratic People''s Republic of', NULL, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (263, N'KR', N'Korea, Republic of', NULL, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (264, N'LA', N'Lao People''s Democratic Republic', NULL, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (265, N'MD', N'Moldova, Republic of', NULL, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (266, N'MK', N'Macedonia, The former Yugoslav Republic of', NULL, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (267, N'MO', N'Macao', NULL, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (268, N'NL', N'Netherlands', NULL, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (269, N'PN', N'Pitcairn', NULL, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (270, N'PS', N'Palestine, State of', NULL, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (271, N'RE', N'Réunion', NULL, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (272, N'RU', N'Russian Federation', NULL, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (273, N'SH', N'Saint Helena, Ascension and Tristan Da Cunha', NULL, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (274, N'SJ', N'Svalbard and Jan Mayen', NULL, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (275, N'SY', N'Syrian Arab Republic', NULL, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (276, N'TL', N'Timor-Leste', NULL, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (277, N'TW', N'Taiwan, Province of China', NULL, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (278, N'TZ', N'Tanzania, United Republic of', NULL, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (279, N'VA', N'Holy See (Vatican City State)', NULL, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (280, N'VG', N'Virgin Islands, British', NULL, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (281, N'VI', N'Virgin Islands, U.S.', NULL, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (282, N'VN', N'Viet Nam', NULL, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (283, N'WF', N'Wallis and Futuna', NULL, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (284, N'XZ', N'Installations in International Waters', NULL, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (285, N'ME', N'Montenegro', NULL, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (286, N'GG', N'Guernsey', NULL, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (287, N'IM', N'Isle of Man', NULL, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (288, N'AX', N'Åland Islands', NULL, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (289, N'CW', N'Curaçao', NULL, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (290, N'BQ', N'Bonaire, Sint Eustatius and Saba', NULL, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (291, N'BL', N'Saint Barthélemy', NULL, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (292, N'MF', N'Saint Martin (French Part)', NULL, 1)
INSERT dbo.Countries (Id, SortName, Name, PhoneCode, IsDefaultRecord) VALUES (293, N'SX', N'Sint Maarten (Dutch Part)', NULL, 1)
SET IDENTITY_INSERT dbo.Countries OFF
END