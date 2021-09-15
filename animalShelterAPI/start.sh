#!/bin/bash
$(/usr/sbin/sshd -D) &
$(dotnet run)