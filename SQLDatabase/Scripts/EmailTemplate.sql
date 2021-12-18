/*
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
if not exists(select * from dbo.EmailTemplate)
Begin
SET IDENTITY_INSERT dbo.EmailTemplate ON 

INSERT dbo.EmailTemplate (Id, TempleteName, TempleteType, EmailSubject, TempleteContent, IsActive, IsDefaultRecord) VALUES (1, N'Vaishnav Registration', N'Registration', N'Registration & Vaishnav Id ', N'<div style="background-image: url(''http://www.vallabhkankroli.org/images/home_10.gif'');">
    <table style="width: 100%; border: 0px !important; color:white;">
        <tbody>
            <tr>
                <td style="width: 20%;">
                    <img style="height: 100px; display: block; margin-left: auto; margin-right: auto;"
                         src="http://www.vallabhkankroli.org/images/home_08.gif" />
                </td>
                <td style="text-align: center;" style="width: 80%;">
                    <h2><strong>Trutiya Gruh of Pushtimarg - Kankroli</strong></h2>
                </td>
            </tr>
        </tbody>
    </table>
    <p>&nbsp;</p>
    <div style="background-image: linear-gradient(to left, #ffa901 1%, #fee600 50%, #ffad01 100%),                    linear-gradient(to left, #ffa901 1%, #fee600 50%, #ffad01 100%); background-size: 100% 3px; background-position: 0% 0%, 0% 100%; background-repeat: no-repeat; /* other demo stuff */  height: 2px; line-height: 50px; background-color: #222; color: white; text-align: center;">&nbsp;</div>
    <div style="padding:5px;"><p style="color:white;">Dear <strong>#Vaishnav#</strong>,</p>
    <p style="color:white;">Bhagawd Smaran,</p>
    <p style="color:white;">Congratulation, you are now registered with us.</p>
    <p style="color:white;">Please save below information,m which help you as well as us to help you better.</p>
    <table style="width: 100%; color:white; border-collapse: collapse;">
        <tbody>
            <tr style="height: 21px;border: 1px solid #ddd;
    padding: 8px;">
                <td style="width: 100%; height: 21px; text-align: center;border: 1px solid #ddd;
    padding: 8px;" colspan="2"><strong>#Vaishnav#</strong></td>
            </tr>
            <tr style="height: 21px; border: 1px solid #ddd;
    padding: 8px;">
                <td style="width: 25%; height: 21px;border: 1px solid #ddd;
    padding: 8px;"><strong>Vaishnav Id</strong></td>
                <td style="width: 75%; height: 21px;border: 1px solid #ddd;
    padding: 8px;">&nbsp;#VaishnavId#</td>
            </tr>
            <tr style="height: 21px;border: 1px solid #ddd;
    padding: 8px;">
                <td style="width: 25%; height: 21px;border: 1px solid #ddd;
    padding: 8px;"><strong>Address</strong></td>
                <td style="width: 75%; height: 21px;border: 1px solid #ddd;
    padding: 8px;	">
                    &nbsp;#Address#
                </td>
            </tr>
        </tbody>
    </table>
    <p></p>
	</div>
</div>', 1, 1)
SET IDENTITY_INSERT dbo.EmailTemplate OFF
end