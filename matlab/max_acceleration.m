function g_force = max_acceleration(mod_t, mod_v)
%max_acceleration Max Acceleration takes the two parameters mod_t and mod_v
%of the bungee jump and returns the maximum acceleration in positive G's

n = length(mod_t);
a = zeros(1,n); % create acceleration array
for i=2:n  % calculate accelertation at each step
    a(i) = (mod_v(i)-mod_v(i-1))/(mod_t(i)-mod_t(i-1));
end
a1 = max(a);  % maximum positive acceleration
a2 = min(a);  % maximum negative acceleration
if a1 > abs(a2)  % Determine the greater acceleration
    max_accel = a1;
else
    max_accel = a2;
end
g_force = abs(max_accel / 9.8);