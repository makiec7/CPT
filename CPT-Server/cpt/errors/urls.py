from django.conf.urls import url
from . import views

app_name = 'error'

urlpatterns = [
    url(r'^$', views.login_user, name='login_user'),
    url(r'index/$', views.index, name='index'),
    url(r'login/$', views.login_user, name='login_user'),
    url(r'logout/$', views.logout_user, name='logout_user')
]
