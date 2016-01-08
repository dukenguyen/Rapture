/**
 * Copyright (C) 2011-2013 Incapture Technologies LLC
 * 
 * This is an autogenerated license statement. When copyright notices appear below
 * this one that copyright supercedes this statement.
 *
 * Unless required by applicable law or agreed to in writing, software is distributed
 * on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express
 * or implied.
 *
 * Unless explicit permission obtained in writing this software cannot be distributed.
 */

/**
 * This file is autogenerated and any changes will be overwritten.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using DotNetRaptureAPI.Common.FixedTypes;

namespace DotNetRaptureAPI
{
/**
* 
**/

[DataContract]
public class WorkOrderSearch   {
    [DataMember (Name="status")]
    public WorkerExecutionState status { get; set; }

    [DataMember (Name="workOrderURIs")]
    public List<String> workOrderURIs { get; set; }

    [DataMember (Name="startTimeBegin")]
    public long startTimeBegin { get; set; }

    [DataMember (Name="startTimeEnd")]
    public long startTimeEnd { get; set; }

    [DataMember (Name="endTimeBegin")]
    public long endTimeBegin { get; set; }

    [DataMember (Name="endTimeEnd")]
    public long endTimeEnd { get; set; }

   


}
} 

