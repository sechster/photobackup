mount_smbfs //user@SERVER/folder /Volumes/Media

#lista katalogow z formatem 2017-*
ls | grep '[0-9]\{4\}-[0-9]\{2\}-[0-9]\{2\}.*'

#(([0-9]{4}|.+)(-[0-9]{2}-[0-9]{2} - .*)?)

#open 'smb://username:password@server/share'
