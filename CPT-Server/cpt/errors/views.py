from django.shortcuts import render
from .models import Error
from django.core.urlresolvers import reverse
from django.http import HttpResponseRedirect
from django.contrib.auth import authenticate
from django.contrib import auth


def index(request):
    all_errors = Error.objects.all()
    context = {'all_errors': all_errors,
               'fields': Error().get_fields()}

    return render(request, 'errors/index.html', context)


def login_user(request):
    next = request.GET.get('next', 'index/')
    if request.method == "POST":
        username = request.POST['username']
        password = request.POST['password']
        user = authenticate(username=username, password=password)
        if user is not None:
            if user.is_active:
                auth.login(request, user)
                return HttpResponseRedirect(next)
            else:
                return render(request, 'errors/login.html', {'error_message': 'Your account has been disabled'})
        else:
            return render(request, 'errors/login.html', {'error_message': 'Invalid login'})
    return render(request, "errors/login.html", {'redirect_to': next})


def logout_user(request):
    auth.logout(request)
    return HttpResponseRedirect(reverse('error:login_user'))
