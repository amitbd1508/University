function ssq(n,pa,ps)
rand('state',0)
disp('This is a single server queue')
% ps is the service rate
% pa is the arrival rate

% we need some data structure and statistical counters

% whether the server is busy or not
serverBusy=0;



% customers served
customersServed=0;

% the queue
Queue=[]; % initially empty
delay=[];


nextEvent=0; % 0 - arrival 1 - departure

% initially there are no departure and arrival scheduled
nextArrival=realmax;
nextDeparture=realmax;

% simulation time
sTime=0;


% we generate the initial arrival only
% service rates will be generated only when they are entering in the service
nextArrival=geometric(pa);
 


while customersServed<n
	% decide the next event
	if nextArrival<nextDeparture
		nextEvent=0;	
	else
		nextEvent=1;
	end
	
	prevTime=sTime;
	
	if nextEvent==0 % next event arrival
		currentTime=nextArrival;
        if serverBusy ~=0 && currentTime-prevTime ~=0
            rectangle('Position',[prevTime 0 currentTime-prevTime serverBusy],'FaceColor',[0 1 1])
        end
        disp('Arrival At:')
		nextArrival
		% check if the server is busy or not
		if serverBusy == 0% free
			% if server free then go directly to service
			% calculate its delay		
			nextDeparture=currentTime+geometric(ps);
			serverBusy=1;

		else
			% put the new job into the queue
			Queue=[Queue currentTime];	
			
		end
		% generate next arrival
		nextArrival=currentTime+geometric(pa);
		
	else
		currentTime=nextDeparture;
		if serverBusy ~=0 && currentTime-prevTime ~=0
            rectangle('Position',[prevTime 0 currentTime-prevTime serverBusy],'FaceColor',[1 0 1])
        end
		disp('Departure At:')
		nextDeparture
		nextDeparture=realmax;
		% for departure check the queue status
		if length(Queue) == 0
			serverBusy=0;
		else
			% remove from queue and put into service
			nextDeparture=currentTime+geometric(ps);
			jobDeparts=Queue(1);
            delay(customersServed+1)=currentTime-Queue(1);;
			Queue=Queue(2:length(Queue)); % considering FIFO
        end
        
		customersServed=customersServed+1;	
        
	end
	sTime=currentTime;
	

end
totalDelay=0;
for i=1:n
    totalDelay=totalDelay+delay(i);
end
totalDelay/n
axis([0 sTime+1 0 2])
end
