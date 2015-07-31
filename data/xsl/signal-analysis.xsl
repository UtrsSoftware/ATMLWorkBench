<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">

    <xsl:template match="/">
        <html>
            <head>
                <meta http-equiv="content-type" content="text/html; charset=ISO-8859-1" />
                <title>Signal Anaysis</title>
								<style>
								td{
									font-weight: normal; 
									font-family: Calibri;
								}
								
								</style>
            </head>
            <body>
								<div style="float: right;" >
									<table border="0" cellspacing="0">
										<tr><td><img src="data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAGXRFWHRTb2Z0d2FyZQBBZG9iZSBJbWFnZVJlYWR5ccllPAAAAmpJREFUeNqkU01oE1EQ/t52E5PNj01BSqlWyLXeWgvGggpFRAo96c2TImgRKc1B8OLBQ9GmIFVPemlBwYKgFKRQFLyI+bGaUtHYWCzW1ND8NnbT7J/zdpNNtd4cmH3wZr5vvp2ZxwzDwP+YyD+MMfvi9Dh6VA1juo4BTs0jggC0CJgnvzY7ikQjlxdn5qdOcOoW7gW8/svnjl1E98FDUJQKivI6fhZXkVx5j9jyEmqKNjMbxtldBAR+0tnWcebu+Wkk16bw4dsUVJ2ro+rkLkcQFdmHV8lFyDX9PikZtgkGI6zH55Lidy5M4+WnYeQr66ZsUxdryLW8UGxDLJWHZqD3+YiREHhQUXF78PAQFn88QI4kC9QZ1mI5KEOlQ9aASyEDDlce7QFA1zAOK2zaiWD7ASznXpiya+RUAXRApbNKDCP91rRcEuD3mMqO21PgoapWxjYhroasxMgbBgfR16hyuL85atFhTgSN6QvWGIHyr6wluW6jRwxsUuVwqAmeeMsginZbmgQC3eTKGTiJPRJvhq8fbYIjMQb3HgITQtMZGqtjEmjbiH7JpKFXW+FxUfI79se2RRIW2OEESgWGzS3qTRVRuwcbHzH22Zd96nHvxb4uwEskk0kGvb4HEgfT72kKkM0CmYKBLGFsBQuPMVfewMxCuoSVlIBKHnBTNS9120Ndd1KZUo7ha4ohnTFQ4bmPMGf2b8cqd528gYdSKwY6Agw+ydpA8xepFVw2r8zB8zcRpuvVXW+BLNg9hND+XlwR3ehrjIqHVRnR73FMLj3Daw7+52OqG9VGJ7n/r5dbJl8j39r5Gn8LMAAV2Qj37wA9/gAAAABJRU5ErkJggg==" alt="accept.png" /></td><td>Fully Capable</td></tr>
										<tr><td><img src="data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAGXRFWHRTb2Z0d2FyZQBBZG9iZSBJbWFnZVJlYWR5ccllPAAAAyJpVFh0WE1MOmNvbS5hZG9iZS54bXAAAAAAADw/eHBhY2tldCBiZWdpbj0i77u/IiBpZD0iVzVNME1wQ2VoaUh6cmVTek5UY3prYzlkIj8+IDx4OnhtcG1ldGEgeG1sbnM6eD0iYWRvYmU6bnM6bWV0YS8iIHg6eG1wdGs9IkFkb2JlIFhNUCBDb3JlIDUuMC1jMDYxIDY0LjE0MDk0OSwgMjAxMC8xMi8wNy0xMDo1NzowMSAgICAgICAgIj4gPHJkZjpSREYgeG1sbnM6cmRmPSJodHRwOi8vd3d3LnczLm9yZy8xOTk5LzAyLzIyLXJkZi1zeW50YXgtbnMjIj4gPHJkZjpEZXNjcmlwdGlvbiByZGY6YWJvdXQ9IiIgeG1sbnM6eG1wPSJodHRwOi8vbnMuYWRvYmUuY29tL3hhcC8xLjAvIiB4bWxuczp4bXBNTT0iaHR0cDovL25zLmFkb2JlLmNvbS94YXAvMS4wL21tLyIgeG1sbnM6c3RSZWY9Imh0dHA6Ly9ucy5hZG9iZS5jb20veGFwLzEuMC9zVHlwZS9SZXNvdXJjZVJlZiMiIHhtcDpDcmVhdG9yVG9vbD0iQWRvYmUgUGhvdG9zaG9wIENTNS4xIFdpbmRvd3MiIHhtcE1NOkluc3RhbmNlSUQ9InhtcC5paWQ6QkFBRjRGNjA1OEZBMTFFMjk0REZDMkRCOEU5MDA0QjQiIHhtcE1NOkRvY3VtZW50SUQ9InhtcC5kaWQ6QkFBRjRGNjE1OEZBMTFFMjk0REZDMkRCOEU5MDA0QjQiPiA8eG1wTU06RGVyaXZlZEZyb20gc3RSZWY6aW5zdGFuY2VJRD0ieG1wLmlpZDpCQUFGNEY1RTU4RkExMUUyOTRERkMyREI4RTkwMDRCNCIgc3RSZWY6ZG9jdW1lbnRJRD0ieG1wLmRpZDpCQUFGNEY1RjU4RkExMUUyOTRERkMyREI4RTkwMDRCNCIvPiA8L3JkZjpEZXNjcmlwdGlvbj4gPC9yZGY6UkRGPiA8L3g6eG1wbWV0YT4gPD94cGFja2V0IGVuZD0iciI/Pvr+f6oAAAG8SURBVHjalJPPL2NxFMUPfa+tdoFZYFomwULYdizEHyCIkQhhobMgsRA1oRsbRGdjY2Vp13bRhZCQTAyJWNjRROJXgmEifi11IyHhuPcVCR1P5yXv3bx7z/l8z8v7fgGbKxH2025O2ozjgyXk7RZjUv8bEPvhJ49+kgtF5GGE0UEfswaoObXURv6uIJcryaVy8s8Eo6FMSAZAV+LJGLlSTa7V0FVcb1UuV5HHoxkQBeS+mGUYHOoBjucAhxNwmfiU7wGcJmC4gJN5BId78BZiAWKhzwyGvwOnv8TsFoMADBNejxcwnwDal7nqVP8MMBLhUnZGxoHtGRG50kzFOh6Q55EEDgVI40Hl8rhaRfdkBKZzQiE5uV1TZ1/jI2OArw5wi9g0xCC3w4DT7bWq9a59nYtO9epTZM5TkkAs5N9saQ8gv+AGuJeOfMVG8ga1AUlxlw6WSnmwOJtEcPpczcm3f0Eh5EU/udtM7jexsKyB3Gskd5rI837qXHV2+8CCXK+3yAZqJQ+kHnwTaB+jA75XZrudmE5y1Uv+7SAve/9p/ugsBOIKue7LiJ31YVJTIvzlXXM2ANiZnwGPAgwAubrnlQw9nIIAAAAASUVORK5CYII=" alt="warning.png" /></td><td>Partially Capable</td></tr>
										<tr><td><img src="data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAGXRFWHRTb2Z0d2FyZQBBZG9iZSBJbWFnZVJlYWR5ccllPAAAAnlJREFUeNp0k09IVFEUxr9775s/7zVaCkVmUBZBAzOgZlKR1iZatc5wWlVI7bRdJAVGOws3hlQEMaJQm2jZKokWZhnOgIsoC6qRyhlnHGYc9b3XOXd6j7HowOXde+75fu/cc88VqLGp47FeqYyktWM7XNclDw8BIQRKP37CsTcS3a/S4148x4gacY8QaiJ24RLMpia4Va1mkB7lTAbph/fJb58jyOQmAIsh5UTsYh/k9y8oPp+ECARIKSnKgbu+jsiZHji79iD9YAxwHA3RgKmueC+lmIz1XYb69hkbma+ACmB19jVBgiReQ7jtGGCvw2jaDbt5L9Jj9/jvia6puXG8PHLQzT955BZHbrqL3S2uZ9mB8+7iyf366xnvcxzHs44zkA6lyFZ58QzKtPyCNgw/Rijaqr+eKXOLjmNzdJEAyZWyKD1pmlCRemRPRX3BttGn/pz9KlJHcRbMQq5aWQ2QxMj+ggyEoYIEseqw0p+ovV29Zj/vy2AY7kquWmANIJK7vESAECTNg+1HUXc3uQnAa/bzvjSCEPl8TQbsXM5R4Q0IOpd5Y8QXFk/H/Tn7eV/R9cpiDUDQEUpENEJ0hFDIF5TPnoDa2ay/fhFp36BRyhfoBFWAuBPfd72jsX6oLXoApqFgr5aqHUZHglJ0/zb1QkW3swpbKG/YmJ3/gJlsYbB/7uMtxjQOx1v6DjfU3+6IR2GaIWo+6j5uUq+VeUWZlssVzKTm8SZXuHY1tTDG7eK9BQ3pJEjnoVYEI1b1HXlGUWvFEqbfvsf0HzHf7KbHxBA6zpX2rdaQbpK/AHwD7/KlwYHUp1EW//MaPQiNFvzfFjyxB/gtwABumBv4WzBkkgAAAABJRU5ErkJggg==" alt="cancel.png" /></td><td>Not Capable</td></tr>
									</table>
								</div>
                <h4 style="font-family: Verdana;"><big>ATML Worbench - Signal Analysis</big><br/>
                    <span style="font-weight: normal; font-family: Calibri;">RAN: <xsl:value-of select="/signal-analysis/@ran"/></span><br/>
                    <span style="font-weight: normal; font-family: Calibri;">TPS: <xsl:value-of select="/signal-analysis/@tps"/></span><br/>
                    <span style="font-weight: normal; font-family: Calibri;">UUT: <xsl:value-of select="/signal-analysis/uut/name/text()"/>
                        {<xsl:value-of select="/signal-analysis/uut/uuid/text()"/>}</span></h4>
                <xsl:for-each select="/signal-analysis/test-station" >
                    <h3 style="margin-bottom:0px;">
											<xsl:element name="img" >
												<xsl:attribute name="src">
                          <xsl:if test="@capability='fully'" >data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAGXRFWHRTb2Z0d2FyZQBBZG9iZSBJbWFnZVJlYWR5ccllPAAAAmpJREFUeNqkU01oE1EQ/t52E5PNj01BSqlWyLXeWgvGggpFRAo96c2TImgRKc1B8OLBQ9GmIFVPemlBwYKgFKRQFLyI+bGaUtHYWCzW1ND8NnbT7J/zdpNNtd4cmH3wZr5vvp2ZxwzDwP+YyD+MMfvi9Dh6VA1juo4BTs0jggC0CJgnvzY7ikQjlxdn5qdOcOoW7gW8/svnjl1E98FDUJQKivI6fhZXkVx5j9jyEmqKNjMbxtldBAR+0tnWcebu+Wkk16bw4dsUVJ2ro+rkLkcQFdmHV8lFyDX9PikZtgkGI6zH55Lidy5M4+WnYeQr66ZsUxdryLW8UGxDLJWHZqD3+YiREHhQUXF78PAQFn88QI4kC9QZ1mI5KEOlQ9aASyEDDlce7QFA1zAOK2zaiWD7ASznXpiya+RUAXRApbNKDCP91rRcEuD3mMqO21PgoapWxjYhroasxMgbBgfR16hyuL85atFhTgSN6QvWGIHyr6wluW6jRwxsUuVwqAmeeMsginZbmgQC3eTKGTiJPRJvhq8fbYIjMQb3HgITQtMZGqtjEmjbiH7JpKFXW+FxUfI79se2RRIW2OEESgWGzS3qTRVRuwcbHzH22Zd96nHvxb4uwEskk0kGvb4HEgfT72kKkM0CmYKBLGFsBQuPMVfewMxCuoSVlIBKHnBTNS9120Ndd1KZUo7ha4ohnTFQ4bmPMGf2b8cqd528gYdSKwY6Agw+ydpA8xepFVw2r8zB8zcRpuvVXW+BLNg9hND+XlwR3ehrjIqHVRnR73FMLj3Daw7+52OqG9VGJ7n/r5dbJl8j39r5Gn8LMAAV2Qj37wA9/gAAAABJRU5ErkJggg==</xsl:if>
                          <xsl:if test="@capability='partial'" >data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAGXRFWHRTb2Z0d2FyZQBBZG9iZSBJbWFnZVJlYWR5ccllPAAAAyJpVFh0WE1MOmNvbS5hZG9iZS54bXAAAAAAADw/eHBhY2tldCBiZWdpbj0i77u/IiBpZD0iVzVNME1wQ2VoaUh6cmVTek5UY3prYzlkIj8+IDx4OnhtcG1ldGEgeG1sbnM6eD0iYWRvYmU6bnM6bWV0YS8iIHg6eG1wdGs9IkFkb2JlIFhNUCBDb3JlIDUuMC1jMDYxIDY0LjE0MDk0OSwgMjAxMC8xMi8wNy0xMDo1NzowMSAgICAgICAgIj4gPHJkZjpSREYgeG1sbnM6cmRmPSJodHRwOi8vd3d3LnczLm9yZy8xOTk5LzAyLzIyLXJkZi1zeW50YXgtbnMjIj4gPHJkZjpEZXNjcmlwdGlvbiByZGY6YWJvdXQ9IiIgeG1sbnM6eG1wPSJodHRwOi8vbnMuYWRvYmUuY29tL3hhcC8xLjAvIiB4bWxuczp4bXBNTT0iaHR0cDovL25zLmFkb2JlLmNvbS94YXAvMS4wL21tLyIgeG1sbnM6c3RSZWY9Imh0dHA6Ly9ucy5hZG9iZS5jb20veGFwLzEuMC9zVHlwZS9SZXNvdXJjZVJlZiMiIHhtcDpDcmVhdG9yVG9vbD0iQWRvYmUgUGhvdG9zaG9wIENTNS4xIFdpbmRvd3MiIHhtcE1NOkluc3RhbmNlSUQ9InhtcC5paWQ6QkFBRjRGNjA1OEZBMTFFMjk0REZDMkRCOEU5MDA0QjQiIHhtcE1NOkRvY3VtZW50SUQ9InhtcC5kaWQ6QkFBRjRGNjE1OEZBMTFFMjk0REZDMkRCOEU5MDA0QjQiPiA8eG1wTU06RGVyaXZlZEZyb20gc3RSZWY6aW5zdGFuY2VJRD0ieG1wLmlpZDpCQUFGNEY1RTU4RkExMUUyOTRERkMyREI4RTkwMDRCNCIgc3RSZWY6ZG9jdW1lbnRJRD0ieG1wLmRpZDpCQUFGNEY1RjU4RkExMUUyOTRERkMyREI4RTkwMDRCNCIvPiA8L3JkZjpEZXNjcmlwdGlvbj4gPC9yZGY6UkRGPiA8L3g6eG1wbWV0YT4gPD94cGFja2V0IGVuZD0iciI/Pvr+f6oAAAG8SURBVHjalJPPL2NxFMUPfa+tdoFZYFomwULYdizEHyCIkQhhobMgsRA1oRsbRGdjY2Vp13bRhZCQTAyJWNjRROJXgmEifi11IyHhuPcVCR1P5yXv3bx7z/l8z8v7fgGbKxH2025O2ozjgyXk7RZjUv8bEPvhJ49+kgtF5GGE0UEfswaoObXURv6uIJcryaVy8s8Eo6FMSAZAV+LJGLlSTa7V0FVcb1UuV5HHoxkQBeS+mGUYHOoBjucAhxNwmfiU7wGcJmC4gJN5BId78BZiAWKhzwyGvwOnv8TsFoMADBNejxcwnwDal7nqVP8MMBLhUnZGxoHtGRG50kzFOh6Q55EEDgVI40Hl8rhaRfdkBKZzQiE5uV1TZ1/jI2OArw5wi9g0xCC3w4DT7bWq9a59nYtO9epTZM5TkkAs5N9saQ8gv+AGuJeOfMVG8ga1AUlxlw6WSnmwOJtEcPpczcm3f0Eh5EU/udtM7jexsKyB3Gskd5rI837qXHV2+8CCXK+3yAZqJQ+kHnwTaB+jA75XZrudmE5y1Uv+7SAve/9p/ugsBOIKue7LiJ31YVJTIvzlXXM2ANiZnwGPAgwAubrnlQw9nIIAAAAASUVORK5CYII=</xsl:if>
                          <xsl:if test="@capability='none'" >data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAGXRFWHRTb2Z0d2FyZQBBZG9iZSBJbWFnZVJlYWR5ccllPAAAAnlJREFUeNp0k09IVFEUxr9775s/7zVaCkVmUBZBAzOgZlKR1iZatc5wWlVI7bRdJAVGOws3hlQEMaJQm2jZKokWZhnOgIsoC6qRyhlnHGYc9b3XOXd6j7HowOXde+75fu/cc88VqLGp47FeqYyktWM7XNclDw8BIQRKP37CsTcS3a/S4148x4gacY8QaiJ24RLMpia4Va1mkB7lTAbph/fJb58jyOQmAIsh5UTsYh/k9y8oPp+ECARIKSnKgbu+jsiZHji79iD9YAxwHA3RgKmueC+lmIz1XYb69hkbma+ACmB19jVBgiReQ7jtGGCvw2jaDbt5L9Jj9/jvia6puXG8PHLQzT955BZHbrqL3S2uZ9mB8+7iyf366xnvcxzHs44zkA6lyFZ58QzKtPyCNgw/Rijaqr+eKXOLjmNzdJEAyZWyKD1pmlCRemRPRX3BttGn/pz9KlJHcRbMQq5aWQ2QxMj+ggyEoYIEseqw0p+ovV29Zj/vy2AY7kquWmANIJK7vESAECTNg+1HUXc3uQnAa/bzvjSCEPl8TQbsXM5R4Q0IOpd5Y8QXFk/H/Tn7eV/R9cpiDUDQEUpENEJ0hFDIF5TPnoDa2ay/fhFp36BRyhfoBFWAuBPfd72jsX6oLXoApqFgr5aqHUZHglJ0/zb1QkW3swpbKG/YmJ3/gJlsYbB/7uMtxjQOx1v6DjfU3+6IR2GaIWo+6j5uUq+VeUWZlssVzKTm8SZXuHY1tTDG7eK9BQ3pJEjnoVYEI1b1HXlGUWvFEqbfvsf0HzHf7KbHxBA6zpX2rdaQbpK/AHwD7/KlwYHUp1EW//MaPQiNFvzfFjyxB/gtwABumBv4WzBkkgAAAABJRU5ErkJggg==</xsl:if>
                        </xsl:attribute>
												<xsl:attribute name="title">
                          <xsl:if test="@capability='fully'" >Fully Capable</xsl:if>
                          <xsl:if test="@capability='partial'" >Partially Capable</xsl:if>
                          <xsl:if test="@capability='none'" >Not Capable</xsl:if>
                        </xsl:attribute>
                      </xsl:element>
											<span style="font-weight: bold; font-family: Calibri;margin-left:10px;margin-bottom:5px;">
												<xsl:value-of select="@name"/> {<xsl:value-of select="@uuid"/> }
											</span>
										</h3>
                    <table style="border:1px solid black; text-align: left; width: 100%; font-family: Calibri;" cellpadding="2" cellspacing="0">
                        <tbody>
                            <xsl:for-each select="signal" >
                                <tr>
                                    <td style="color: white; background-color: rgb(33, 71, 145); width: 100%;"
                                        colspan="3" rowspan="1"><xsl:value-of select="@type"/></td>
                                </tr>
                                <xsl:for-each select="signal-instance" >
                                        <xsl:element name="tr">
                                            <xsl:attribute name="style" >border-bottom:1px solid black; 
                                                <xsl:if test="@capability='fully'" >background-color: rgb(220, 255, 220);</xsl:if>
                                                <xsl:if test="@capability='partial'" >background-color: rgb(255, 255, 220);</xsl:if>
                                                <xsl:if test="@capability='none'" >background-color: rgb(255, 220, 220);</xsl:if>
                                            </xsl:attribute>
                                            <td style="width:17px;" >
                                                <xsl:element name="img" >
                                                    <xsl:attribute name="src">
                                                        <xsl:if test="@capability='fully'" >data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAGXRFWHRTb2Z0d2FyZQBBZG9iZSBJbWFnZVJlYWR5ccllPAAAAmpJREFUeNqkU01oE1EQ/t52E5PNj01BSqlWyLXeWgvGggpFRAo96c2TImgRKc1B8OLBQ9GmIFVPemlBwYKgFKRQFLyI+bGaUtHYWCzW1ND8NnbT7J/zdpNNtd4cmH3wZr5vvp2ZxwzDwP+YyD+MMfvi9Dh6VA1juo4BTs0jggC0CJgnvzY7ikQjlxdn5qdOcOoW7gW8/svnjl1E98FDUJQKivI6fhZXkVx5j9jyEmqKNjMbxtldBAR+0tnWcebu+Wkk16bw4dsUVJ2ro+rkLkcQFdmHV8lFyDX9PikZtgkGI6zH55Lidy5M4+WnYeQr66ZsUxdryLW8UGxDLJWHZqD3+YiREHhQUXF78PAQFn88QI4kC9QZ1mI5KEOlQ9aASyEDDlce7QFA1zAOK2zaiWD7ASznXpiya+RUAXRApbNKDCP91rRcEuD3mMqO21PgoapWxjYhroasxMgbBgfR16hyuL85atFhTgSN6QvWGIHyr6wluW6jRwxsUuVwqAmeeMsginZbmgQC3eTKGTiJPRJvhq8fbYIjMQb3HgITQtMZGqtjEmjbiH7JpKFXW+FxUfI79se2RRIW2OEESgWGzS3qTRVRuwcbHzH22Zd96nHvxb4uwEskk0kGvb4HEgfT72kKkM0CmYKBLGFsBQuPMVfewMxCuoSVlIBKHnBTNS9120Ndd1KZUo7ha4ohnTFQ4bmPMGf2b8cqd528gYdSKwY6Agw+ydpA8xepFVw2r8zB8zcRpuvVXW+BLNg9hND+XlwR3ehrjIqHVRnR73FMLj3Daw7+52OqG9VGJ7n/r5dbJl8j39r5Gn8LMAAV2Qj37wA9/gAAAABJRU5ErkJggg==</xsl:if>
                                                        <xsl:if test="@capability='partial'" >data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAGXRFWHRTb2Z0d2FyZQBBZG9iZSBJbWFnZVJlYWR5ccllPAAAAyJpVFh0WE1MOmNvbS5hZG9iZS54bXAAAAAAADw/eHBhY2tldCBiZWdpbj0i77u/IiBpZD0iVzVNME1wQ2VoaUh6cmVTek5UY3prYzlkIj8+IDx4OnhtcG1ldGEgeG1sbnM6eD0iYWRvYmU6bnM6bWV0YS8iIHg6eG1wdGs9IkFkb2JlIFhNUCBDb3JlIDUuMC1jMDYxIDY0LjE0MDk0OSwgMjAxMC8xMi8wNy0xMDo1NzowMSAgICAgICAgIj4gPHJkZjpSREYgeG1sbnM6cmRmPSJodHRwOi8vd3d3LnczLm9yZy8xOTk5LzAyLzIyLXJkZi1zeW50YXgtbnMjIj4gPHJkZjpEZXNjcmlwdGlvbiByZGY6YWJvdXQ9IiIgeG1sbnM6eG1wPSJodHRwOi8vbnMuYWRvYmUuY29tL3hhcC8xLjAvIiB4bWxuczp4bXBNTT0iaHR0cDovL25zLmFkb2JlLmNvbS94YXAvMS4wL21tLyIgeG1sbnM6c3RSZWY9Imh0dHA6Ly9ucy5hZG9iZS5jb20veGFwLzEuMC9zVHlwZS9SZXNvdXJjZVJlZiMiIHhtcDpDcmVhdG9yVG9vbD0iQWRvYmUgUGhvdG9zaG9wIENTNS4xIFdpbmRvd3MiIHhtcE1NOkluc3RhbmNlSUQ9InhtcC5paWQ6QkFBRjRGNjA1OEZBMTFFMjk0REZDMkRCOEU5MDA0QjQiIHhtcE1NOkRvY3VtZW50SUQ9InhtcC5kaWQ6QkFBRjRGNjE1OEZBMTFFMjk0REZDMkRCOEU5MDA0QjQiPiA8eG1wTU06RGVyaXZlZEZyb20gc3RSZWY6aW5zdGFuY2VJRD0ieG1wLmlpZDpCQUFGNEY1RTU4RkExMUUyOTRERkMyREI4RTkwMDRCNCIgc3RSZWY6ZG9jdW1lbnRJRD0ieG1wLmRpZDpCQUFGNEY1RjU4RkExMUUyOTRERkMyREI4RTkwMDRCNCIvPiA8L3JkZjpEZXNjcmlwdGlvbj4gPC9yZGY6UkRGPiA8L3g6eG1wbWV0YT4gPD94cGFja2V0IGVuZD0iciI/Pvr+f6oAAAG8SURBVHjalJPPL2NxFMUPfa+tdoFZYFomwULYdizEHyCIkQhhobMgsRA1oRsbRGdjY2Vp13bRhZCQTAyJWNjRROJXgmEifi11IyHhuPcVCR1P5yXv3bx7z/l8z8v7fgGbKxH2025O2ozjgyXk7RZjUv8bEPvhJ49+kgtF5GGE0UEfswaoObXURv6uIJcryaVy8s8Eo6FMSAZAV+LJGLlSTa7V0FVcb1UuV5HHoxkQBeS+mGUYHOoBjucAhxNwmfiU7wGcJmC4gJN5BId78BZiAWKhzwyGvwOnv8TsFoMADBNejxcwnwDal7nqVP8MMBLhUnZGxoHtGRG50kzFOh6Q55EEDgVI40Hl8rhaRfdkBKZzQiE5uV1TZ1/jI2OArw5wi9g0xCC3w4DT7bWq9a59nYtO9epTZM5TkkAs5N9saQ8gv+AGuJeOfMVG8ga1AUlxlw6WSnmwOJtEcPpczcm3f0Eh5EU/udtM7jexsKyB3Gskd5rI837qXHV2+8CCXK+3yAZqJQ+kHnwTaB+jA75XZrudmE5y1Uv+7SAve/9p/ugsBOIKue7LiJ31YVJTIvzlXXM2ANiZnwGPAgwAubrnlQw9nIIAAAAASUVORK5CYII=</xsl:if>
                                                        <xsl:if test="@capability='none'" >data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAGXRFWHRTb2Z0d2FyZQBBZG9iZSBJbWFnZVJlYWR5ccllPAAAAnlJREFUeNp0k09IVFEUxr9775s/7zVaCkVmUBZBAzOgZlKR1iZatc5wWlVI7bRdJAVGOws3hlQEMaJQm2jZKokWZhnOgIsoC6qRyhlnHGYc9b3XOXd6j7HowOXde+75fu/cc88VqLGp47FeqYyktWM7XNclDw8BIQRKP37CsTcS3a/S4148x4gacY8QaiJ24RLMpia4Va1mkB7lTAbph/fJb58jyOQmAIsh5UTsYh/k9y8oPp+ECARIKSnKgbu+jsiZHji79iD9YAxwHA3RgKmueC+lmIz1XYb69hkbma+ACmB19jVBgiReQ7jtGGCvw2jaDbt5L9Jj9/jvia6puXG8PHLQzT955BZHbrqL3S2uZ9mB8+7iyf366xnvcxzHs44zkA6lyFZ58QzKtPyCNgw/Rijaqr+eKXOLjmNzdJEAyZWyKD1pmlCRemRPRX3BttGn/pz9KlJHcRbMQq5aWQ2QxMj+ggyEoYIEseqw0p+ovV29Zj/vy2AY7kquWmANIJK7vESAECTNg+1HUXc3uQnAa/bzvjSCEPl8TQbsXM5R4Q0IOpd5Y8QXFk/H/Tn7eV/R9cpiDUDQEUpENEJ0hFDIF5TPnoDa2ay/fhFp36BRyhfoBFWAuBPfd72jsX6oLXoApqFgr5aqHUZHglJ0/zb1QkW3swpbKG/YmJ3/gJlsYbB/7uMtxjQOx1v6DjfU3+6IR2GaIWo+6j5uUq+VeUWZlssVzKTm8SZXuHY1tTDG7eK9BQ3pJEjnoVYEI1b1HXlGUWvFEqbfvsf0HzHf7KbHxBA6zpX2rdaQbpK/AHwD7/KlwYHUp1EW//MaPQiNFvzfFjyxB/gtwABumBv4WzBkkgAAAABJRU5ErkJggg==</xsl:if>
                                                    </xsl:attribute>
                                                </xsl:element>
                                            </td>
                                            <td><xsl:value-of select="@tsf"/></td>
                                            <td>
                                                <xsl:for-each select="attribute" >
                                                    <xsl:element name="span" >
                                                        <xsl:if test="@valid='false'" >
                                                            <xsl:attribute name="style">color:red;</xsl:attribute>
                                                        </xsl:if>
                                                    <xsl:value-of select="@name"/>=<xsl:value-of select="text()"/>
                                                    </xsl:element>
                                                    <xsl:if test="position() != last()" >, </xsl:if>
                                                </xsl:for-each>
                                                <xsl:if test="cause" >
                                                    <br/>
                                                    <span style="padding-left:10px; color: darkred; font-weight:bold;" >
                                                        cause:
                                                        <xsl:for-each select="cause/attribute" >
                                                            <xsl:value-of select="@name"/> - <xsl:value-of select="text()"/>
                                                            <xsl:if test="position() != last()" >, </xsl:if>
                                                        </xsl:for-each>
                                                    </span>
                                                </xsl:if>
                                            </td>
                                        </xsl:element>
                                </xsl:for-each>
                            </xsl:for-each>
                        </tbody>
                    </table>
                    <br/>
                </xsl:for-each>
            </body>
        </html>
    </xsl:template>

</xsl:stylesheet>