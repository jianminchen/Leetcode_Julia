July 21, 2020<br>
[Database Master-Slave Replication in the Cloud](https://mariadb.com/resources/blog/database-master-slave-replication-in-the-cloud/)<br>

Scale-out solutions — spreading the load among multiple slaves to improve performance. In this environment, all writes and updates must take place on the master server. Reads, however, may take place on one or more slaves. This model can improve the performance of writes (since the master is dedicated to updates), while dramatically increasing read speed across an increasing number of slaves.<br>

Statements<br>
Scale-out solutions — spreading the load among multiple slaves to improve performance. <br>
Multiple slaves - take increasing read load -<br>

In this environment, all writes and updates must take place on the master server. Reads, however, may take place on one or more slaves. <br>
This model can improve the performance of writes (since the master is dedicated to updates), while dramatically increasing read speed across an increasing number of slaves.<br>
The master is dedicated to updates. <br>
scale-out solution - increase number of slaves for read need. <br>
So it is better to scale out instead of scaling up. <br>

Data security<br>
Data security — as data is replicated to the slave, and the slave can pause the replication process, it is possible to run backup services on the slave without corrupting the corresponding master data. <br>
Analytics — live data can be created on the master, while the analysis of the information can take place on the slave without affecting the performance of the master.<br>
Slave is the one to take care of analysis of information. <br>

Scale-out: Replication in this situation enables us to distribute the reads over the replication slaves, while still enabling our web servers to communicate with the replication master when a write is required.<br>


Increasing the peroformance: <br>
One way is to create a deeper replication structure taht enables the master to replicate to only one slave, and for the remaining slaves to connect to this primary slave for their individual replication requirements. <br>

Failover alleviating:<br>
Monitor the master to check whether it is up. Change master if needed. <br>

