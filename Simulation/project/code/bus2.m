function bus2()
   
   N=80*60*60;
   %N=500;
   pa=.538;
   ps1=14;
   ps2=10;
   ps=24;
   time=0;
   server=0;
   man=0;
   Q=[]; %terminal 3 queue
   Q1=[];
   Q2=[];
   
   MS1=[];
   MS2=[];
   MS3=[];
   
   D1=[];
   D2=[];
   D3=[];
   
   dc1=1;
   dc2=1;
   dc3=1;
   
   MB1=[];%man inthe bus 
   MB2=[];
   MB3=[];
   
   INBUS=[];
   
   personstay=[];
   ma=[];
   md=[];
   
   mac=1;
   mdc=1;
   
   maxSizeQ=[];
   
   %for ques f ans from Dealy
   maxnuminq=0;
   minnuminq=100;
   
   inq=[];
   inqc=1;
   
   terminal=3;
   
   people=0;
   
   nextEvent=0;
   
   nextA=realmax; %terminal 3Arival
   nextD=realmax;% terminal 3 Depart
   
   nextA2=realmax;
   nextD2=realmax;
   nextA1=realmax;
   nextD1=realmax;
   
   nextA=expon(pa);
   
   current=0;
   current1=0;
   current2=0;
   
   std=5*60;
   
   
   
   i=2;
   j=0;
   
   start=0;
   cou=0;
   
   maxtimestayatstop=0;
   while time<N
       cou=cou+1;
       temp=time-start;
       if temp>=std;
           maxtimestayatstop=max(temp,maxtimestayatstop);
           start=time;
           if j==0
               terminal=3;
           elseif j==1
                   terminal=1;
           elseif j==2
                   terminal=2;
                       
           end
               
           j=mod(j,3);
           j=j+1;
           terminal=3;
               
       end
       
       
       
       
       if terminal==3  % for terminal 3
           if nextA<nextD
               nextEvent=0;
           else
               nextEvent=1;
           end %end if

           prevTime=time;
           if length(Q)>20
               server=1;
           end
           maxnuminq=max(maxnuminq,length(Q));
           minnuminq=min(minnuminq,length(Q));
           inq(inqc)=length(Q);
           inqc=inqc+1;
           if nextEvent==0
               current=nextA;
               %disp('Arrive at');
               %nextA
               people=people+1;
               ma(mac)=current;
               mac=mac+1;
               
               if server==0 
                   nextD=current+expon(ps)+uniform(16,24)+uniform(15,25);%load+unload+service time
                   server=1;
               else
                   Q=[Q current];
               end %end server if
               nextA=current+expon(ps);
           else
               current=nextD;
               %disp('Depart at');
               %nextD
               nextD=realmax;
               
               if length(Q)==0
                    server=0;
               else

                   people=people-1;
                   nextD=current+expon(ps)+uniform(16,24)+uniform(15,25);
                   job=Q(1);
                   Q=Q(2:length(Q));
                   D3(dc3)=current-job;
                   dc3=dc3+1;
                   man=man+1;
                   md(mdc)=job;
                   mdc=mdc+1;
               end
               

           end %end event if
           time=current;
                    
       end %end terminal 3 if
       
       
       if terminal==1
           if nextA1<nextD1
               nextEvent1=0;
           else
               nextEvent1=1;
           end %end if

           prevTime=time;

            maxnuminq=max(maxnuminq,length(Q));
           minnuminq=min(minnuminq,length(Q));
           inq(inqc)=length(Q);
           if nextEvent1==0 %Arrive 1 
               current=nextA1;
               %disp('Arrive at');
               %nextA1
               people=people+1;
               if people>20
                   server=1;
               end
               

               if server==0
                   nextD1=current+expon(ps1)+uniform(16,24)+uniform(15,25);%+load+unload+service
                   server=1;
               else
                   Q1=[Q1 current];
               end %end server if
               nextA1=current+expon(pa);
           else
               current=nextD1;
               %disp('Depart at');
               %nextD1
               nextD1=realmax;

               if length(Q1)==0
                    server=0;
               else

                   people=people-1;
                   nextD1=current+expon(ps1)+uniform(16,24)+uniform(15,25);%load+unload+service
                   job1=Q1(1);
                   D1(dc1)=current-job1;
                   dc1=dc1+1;
                   Q1=Q1(2:length(Q1));
                   man=man+1;
               end
               

           end %end event if
           time=current;
           
           %block
           nextA2=current+expon(ps);
           
       end % end terminal 1 if
       
       if terminal==2
           
           if nextA2<nextD2
               nextEvent2=0;
           else
               nextEvent2=1;
           end %end if

           prevTime=time;

            maxnuminq=max(maxnuminq,length(Q));
           minnuminq=min(minnuminq,length(Q));
           inq(inqc)=length(Q);
           if nextEvent2==0 %Arrive 2 
               current=nextA2;
               %disp('Arrive at');
               %nextA2
               people=people+1;
               if people>20
                   server=1;
                   
               end

               if server==0
                   nextD2=current+expon(ps2)+uniform(16,24)+uniform(15,25);%+load+unload+service
                   server=1;
               else
                   Q2=[Q2 current];
               end %end server if
               nextA2=current+expon(pa);
           else
               current=nextD2;
               %disp('Depart2 at');
               %nextD2
               nextD2=realmax;

               if length(Q2)==0
                    server=0;
               else

                   people=people-1;
                   nextD2=current+expon(ps2)+uniform(16,24)+uniform(15,25);%load+unload+service
                   job2=Q2(1);
                   D2(dc2)=current-job2;
                   dc2=dc2+1;
                   Q2=Q2(2:length(Q2));
                   man=man+1;
               end
               
           end
           
           %block
           nextA=current+expon(ps);
           
           
           time=current;
       end % end terminal 2 if
       
       
   end %end While
   disp(['Total Number of people served   ',num2str(man)])
   totalDelay=0;
   
   if mdc<mac
      mac=mdc ;
   end
   for i=1:mac-1
      ma(i)=md(i)-ma(i);
   end
   maximumTimeStay=max(ma);
   minimumtimeofapersonstay=min(ma);
   
   tot=0;
   for i=1:mac-1
       tot=tot+ma(i);
   end
   for i=1:length(D3)
        totalDelay=totalDelay+D3(i);
    end
    avgofd3=totalDelay/dc3;
    maximumd3=max(D3);
    maxtimestayatstop;
    disp(['total  delay  ',num2str(totalDelay),' avg  delay  ',num2str(avgofd3)]);
    disp(['maximum  delay  ',num2str(maximumd3),'  ',' minimum delay  ',num2str(min(D3))]);
    
    disp(['maximum  stay  ',num2str(maximumTimeStay),'  ',' minimum stay  ',num2str((minimumtimeofapersonstay))]);
    disp(['avg of stay  ',num2str(tot/mac)]);
    
    disp(['maximum  in  queue  ',num2str(max(inq)),'  ',' minimum in queue  ',num2str(min(inq))]);
    tt=0;
    for i=1:length(inq)
        tt=tt+inq(i);
    end
    disp(['avg in queue  ',num2str(tt/length(inq))]);
end
